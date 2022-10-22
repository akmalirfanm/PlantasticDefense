using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CameraController : MonoBehaviour
{

    public float zoomOutMin = 1;
    public float zoomOutMax = 9;

    Vector3 touchStart;

    private bool canPan;

    private float limitX;
    private float limitY;

    float yMinLimit = 0f;
    float yMaxLimit = 17f;

    float xMinLimit = -14f;
    float xMaxLimit = 7;

    [SerializeField]
    private List<GameObject> _groundList;

    private void Update()
    {




        if (Input.GetMouseButtonDown(0))
        {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                         touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                        if (hit.collider != null &&  hit.collider.gameObject.tag == "Tower Placement" && !EventSystem.current.IsPointerOverGameObject())
                        {
                            canPan = true;
                        }

                if (hit.collider == null || hit.collider.gameObject.tag != "Tower Placement")
                {
                    canPan = false;
                }
                    }
        }

        if (Input.GetMouseButtonUp(0))
        {
            canPan = false;
        }

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

        else if (Input.GetMouseButton(0) && canPan)
        {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += direction;
            
        }
        Zoom(Input.GetAxis("Mouse ScrollWheel") * 5);
    }

    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    public void AddGround(GameObject ground)
    {
        _groundList.Add(ground);
    }

    public void DeleteGround(GameObject ground)
    {
        int idx = _groundList.IndexOf(ground);
       // _groundList.RemoveAt(idx);
    }

}
