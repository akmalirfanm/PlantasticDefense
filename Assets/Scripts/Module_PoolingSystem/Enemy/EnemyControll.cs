using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;
using Plantastic.Module_Enemy;

[System.Serializable]
public class EnemyControll
{
    [SerializeField]
    private BaseEnemy basicPref;


    /*public int count;
    public int rate;*/
    PoolingSystem pool = new PoolingSystem();

    public GameObject CreateObject(Vector3 pos)
    {
        return pool.CreateObject(basicPref, pos).gameObject;
    }
}
