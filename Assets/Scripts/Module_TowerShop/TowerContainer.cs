using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_TowerShop
{
    public struct TowerContainer
    {
        public GameObject towerObj;
        public Vector3 posTower;
        public int price;
        public int version;

        public TowerContainer(GameObject towerObj, Vector3 posTower, int price, int version)
        {
            this.towerObj = towerObj;
            this.posTower = posTower;
            this.price = price;
            this.version = version;
        }
    }
}
