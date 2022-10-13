using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruObj2 : BasePeluru
{
    private void Start()
    {
        speed = 10;
    }
    public override void OnCreate()
    {
        hp = 900;
        Invoke("StoreToPool", 5f);
    }
    public override void StoreToPool()
    {
        base.StoreToPool();
    }
}
