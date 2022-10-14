using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_PoolingSystem
{
    public class BulletControlls : MonoBehaviour
    {
        [SerializeField]
        BasePeluru peluruPrefs;

        PoolingSystem pool = new PoolingSystem();

        public GameObject CreateObject(Vector3 pos)
        {
            return pool.CreateObject(peluruPrefs, pos).gameObject;
        }
    }
}

