using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraController : MonoBehaviour
{
    public RectTransform _cam;
    public Camera cam;
    public float scrollSpeed = 0.5f;
    public float limitZoomSize = 5f;

    public float moveSpeed = 0.2f;
    public float limitMove = 0.54f;
    float tempCamSize;

    // q w E
    // z y x
    private void Start()
    {
        tempCamSize = cam.orthographicSize;
        _cam = GetComponent<RectTransform>();
    }
    private void Update()
    {
        ZoomCamera();
        MoveCamera();
    }
    void MoveCamera()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.W))
        {

        }
        if(Input.GetKeyDown(KeyCode.E))
        {

        }
    }
    void ZoomCamera()
    {
        var limit = tempCamSize - limitZoomSize;
        var _input = Input.GetAxis("Mouse ScrollWheel");
        // zoom in
        if (_input > 0f)
        {
            if (cam.orthographicSize > limit)
            {
                cam.orthographicSize -= 1 * scrollSpeed;
            }
        }
        // zoom out
        if (_input < 0f)
        {
            if (cam.orthographicSize < tempCamSize)
            {
                cam.orthographicSize += 1 * scrollSpeed;   
            }
        }
    }    
}
