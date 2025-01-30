using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCallVFX : MonoBehaviour
{
    private void Start()
    {
        CallVFX();
    }
    void CallVFX()
    {
        string _name = "Explode";
        Vector3 pos = new Vector3(2, 2, 2);
        EventManager.TriggerEvent("OnPlayVfxName", _name);
        EventManager.TriggerEvent("OnPlayVfxPos", pos);
    }
}
