using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;

namespace Plantastic.Module_VFX
{
    [System.Serializable]
    public class Vfx
    {
        public VfxObject visualPref;
        PoolingSystem pool = new PoolingSystem();
        public GameObject CreateObject(Vector3 pos)
        {
            return pool.CreateObject(visualPref, pos).gameObject;
        }
    }
}