using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyUIFaceCamera : MonoBehaviour
    {
        private void Update()
        {
            FaceCamera();
        }

        private void FaceCamera()
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(Vector3.up, 180f);
        }
    }
}

