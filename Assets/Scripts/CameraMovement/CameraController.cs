using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public float zoomOutMin = 1;
    public float zoomOutMax = 9;

    private Vector3 lastMousePosition;
    private bool canPan;

    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private float dragSmoothTime = 0.1f; // makin kecil makin responsif

    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    private float initialZ;

    [SerializeField]
    private List<GameObject> _groundList;

    private void Start()
    {
        initialZ = virtualCamera.transform.localPosition.z;
        targetPosition = virtualCamera.transform.localPosition;
    }

    private void Update()
    {
        HandleMouseDrag();
        HandleZoomInput();
    }

    private void LateUpdate()
    {
        // Smooth move ke posisi target
        virtualCamera.transform.localPosition = Vector3.SmoothDamp(
            virtualCamera.transform.localPosition,
            targetPosition,
            ref velocity,
            dragSmoothTime
        );

        // Lock Z-nya tetap
        Vector3 localPos = virtualCamera.transform.localPosition;
        localPos.z = initialZ;
        virtualCamera.transform.localPosition = localPos;
    }

    private void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                lastMousePosition = Input.mousePosition;
                canPan = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            canPan = false;
        }

        if (Input.GetMouseButton(0) && canPan)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            // Hitung factor berdasarkan zoom ortografik
            float factor = virtualCamera.m_Lens.OrthographicSize / 5f;

            // Gerakan kamera di layar, arah kebalikan dari drag
            Vector3 move = new Vector3(-delta.x, -delta.y, 0) * factor * 0.01f;

            // Update target position
            targetPosition += move;

            lastMousePosition = Input.mousePosition;
        }
    }

    private void HandleZoomInput()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;
            Zoom(difference * 0.01f);
        }
        else
        {
            Zoom(Input.GetAxis("Mouse ScrollWheel") * 5);
        }
    }

    void Zoom(float increment)
    {
        virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(
            virtualCamera.m_Lens.OrthographicSize - increment,
            zoomOutMin,
            zoomOutMax
        );
    }

    public void AddGround(GameObject ground)
    {
        _groundList.Add(ground);
    }

    public void DeleteGround(GameObject ground)
    {
        int idx = _groundList.IndexOf(ground);
        // _groundList.RemoveAt(idx); // aktifkan kalau mau hapus
    }
}
