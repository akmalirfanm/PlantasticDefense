using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;

//  scirpt ini dimasukan ke dalam prefab
public class PeluruObject : PoolObject
{
    public float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    #region Object Pool
    public override void OnCreate()
    {
        // dilakukan pertama kali saat object active
        Invoke("StoreToPool", 3f);
    }
    public override void StoreToPool()
    {
        base.StoreToPool();
    }
    #endregion
}
