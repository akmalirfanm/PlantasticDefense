using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;

//  scirpt ini dimasukan ke dalam prefab
public class PeluruObj1 : BasePeluru
{
    private void Start()
    {
        speed = 23;
    }
    public override void OnCreate()
    {
        hp = 100;
        Invoke("StoreToPool", 3f);
    }
    public override void StoreToPool()
    {
        base.StoreToPool();
    }
}
