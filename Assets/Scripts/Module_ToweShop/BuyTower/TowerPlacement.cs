using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_TowerShop
{
    public class TowerPlacement : MonoBehaviour
    {
        [HideInInspector]
        public bool isFull; 
        public Vector3 offsetPos;

        public void BuildTower(GameObject tower)
        {
            if (isFull)
            {
                Debug.LogWarning("This Place alredy have tower");
                return;
            }
            GameObject _tower = Instantiate(tower, transform.position + offsetPos, Quaternion.identity);
            isFull = true;
        }
    }
}

