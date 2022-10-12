using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Plantastic.Module_VFX
{
    public class VfxManager : MonoBehaviour
    {
        [SerializeField]
        private Vfx[] visualEffect;


        private void OnEnable()
        {
            EventManager.StartListening("OnPlayVFX", PlayVfx);
        }
        private void OnDisable()
        {
            EventManager.StopListening("OnPlayVFX", PlayVfx);
        }
        void PlayVfx(object nameVfx, object pos)
        {
            nameVfx = (string)nameVfx;
            pos = (Vector3)pos;
            Vfx v = Array.Find(visualEffect, vfx => vfx.visualPref.name == nameVfx);
            //Instantiate(v.visualPref, message.position, Quaternion.identity);
            v.CreateObject(pos).transform.SetParent(this.transform);
        }
    }
}