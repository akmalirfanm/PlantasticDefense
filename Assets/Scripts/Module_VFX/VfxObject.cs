using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;


namespace Plantastic.Module_VFX
{
    public class VfxObject : PoolObject
    {
        public override void OnCreate()
        {
            Invoke("StoreToPool", 5f);
        }
        public override void StoreToPool()
        {
            base.StoreToPool();
        }

    }
}
