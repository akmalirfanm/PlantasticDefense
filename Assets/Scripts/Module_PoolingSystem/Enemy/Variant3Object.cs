using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;
using Plantastic.Module_Enemy;

public class Variant3Object : EnemyVariant_3, IPoolObject
{
    public PoolingSystem poolingSystem { private set; get; }
    void IPoolObject.Initial(PoolingSystem poolSystem)
    {
        poolingSystem = poolSystem;
    }
    public void OnCreate()
    {
        Invoke("StoreToPool", 3f);
    }
    public virtual void StoreToPool()
    {

        poolingSystem.Store(this);
        gameObject.SetActive(false);
    }
}
