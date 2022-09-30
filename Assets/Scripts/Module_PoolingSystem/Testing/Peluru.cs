using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PD.PoolingSystem;


[System.Serializable]
public class Peluru
{
    public PeluruObject peluruPref;
    PoolingSystem pool = new PoolingSystem();
    public GameObject CreateObject(Vector3 pos)
    {
        return pool.CreateObject(peluruPref, pos).gameObject;
    }
} 
