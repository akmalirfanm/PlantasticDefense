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

        public Transform wayPoint;

        string nameOfVfx;

        private void Update()
        {
            string _name = "enemies_dead";
            Vector3 pos = wayPoint.position;
            EventManager.TriggerEvent("OnPlayVfxName", _name);
            EventManager.TriggerEvent("OnPlayVfxPos", pos);
        }
        private void OnEnable()
        {
            EventManager.StartListening("OnPlayVfxName", VfxName);
            EventManager.StartListening("OnPlayVfxPos", PlayVfx);
        }
        private void OnDisable()
        {
            EventManager.StopListening("OnPlayVfxName", VfxName);
            EventManager.StopListening("OnPlayVfxPos", PlayVfx);
        }
        void VfxName(object name)
        {
            nameOfVfx = (string)name;
        }
        void PlayVfx(object pos)
        {
            pos = (Vector3)pos;
            Vfx v = Array.Find(visualEffect, vfx => vfx.name == nameOfVfx);
            v.CreateObject((Vector3)pos).transform.SetParent(this.transform);
        }
    }
}