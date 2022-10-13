using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class1 : MonoBehaviour
{
    public string data = "data";
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Kirim Pesan");
            EventManager.TriggerEvent("Message", data);
        }
    }
}
