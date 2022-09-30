using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjPool : MonoBehaviour
{
    [SerializeField]
    Peluru[] peluru;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // spawn
            int _random = Random.Range(0, peluru.Length);
            peluru[_random].CreateObject(transform.position);
        }
    }
}
