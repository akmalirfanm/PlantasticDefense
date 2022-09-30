using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_PoolingSystem
{
    public abstract class PoolObject : MonoBehaviour, IPoolObject
    {
        public PoolingSystem poolingSystem { private set; get; }
        void IPoolObject.Initial(PoolingSystem poolSystem)
        {
            poolingSystem = poolSystem;
        }
        public abstract void OnCreate();
        public virtual void StoreToPool()
        {
            poolingSystem.Store(this);
            gameObject.SetActive(false);
        }
    }
}