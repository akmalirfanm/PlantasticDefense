using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class2 : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StartListening("Message", TerimaMessage);
    }
    private void OnDisable()
    {
        EventManager.StopListening("Message", TerimaMessage);
    }
    void TerimaMessage(object pesan)
    {
        Debug.Log("Pesan : " + pesan + " telah diterima");
    }
}
