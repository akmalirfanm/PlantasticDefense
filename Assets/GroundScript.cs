using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private Camera cam;

    private CameraController camControl;

    private void Start()
    {
        cam = Camera.main;
        camControl = cam.GetComponent<CameraController>();
    }
    private void OnBecameVisible()
    {
        camControl.AddGround(gameObject);
    }

    private void OnBecameInvisible()
    {
        camControl.DeleteGround(gameObject);
    }
}
