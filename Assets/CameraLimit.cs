using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    private Camera cam;

    private CameraController camControl;

    private void Start()
    {
        cam = Camera.main;
        camControl = cam.GetComponent<CameraController>();
    }

    private void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            camControl.AddGround(gameObject);
        }
        else
        {
            camControl.DeleteGround(gameObject);
        }
    }
}
