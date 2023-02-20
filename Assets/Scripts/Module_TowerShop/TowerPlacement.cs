using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_TowerShop
{
    public class TowerPlacement : MonoBehaviour
    {
        [SerializeField] private Vector3 offsetPos;

        [HideInInspector] public bool isFull;

        public void BuildTower(GameObject tower, TowerDataSet dataTower)
        {
            if (isFull)
            {
                return;
            }
            TowerManager.Instance.BuildNewTower(tower, transform.position + offsetPos, dataTower);
            isFull = true;
        }
    }
}

