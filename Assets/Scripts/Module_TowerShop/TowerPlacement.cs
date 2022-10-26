using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Resource;

namespace Plantastic.Module_TowerShop
{
    public class TowerPlacement : MonoBehaviour
    {
        [SerializeField] private Vector3 offsetPos;

        [HideInInspector] public bool isFull;

        public void BuildTower(GameObject tower, TowerDataSet dataTower)
        {
            if (isFull || !Resource.Instance.IsResourceEnough(dataTower.version[0].price))
            {
                return;
            }
            TowerManager.Instance.BuildNewTower(tower, transform.position + offsetPos, dataTower);
            isFull = true;
            EventManager.TriggerEvent("SFXMessage", "Build Plant");
        }
    }
}

