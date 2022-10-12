using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_TowerShop
{
    public struct TowerContainer
    {
        public TowerDataSet towerData;
        public TowerPlacement towerPlace;
        public GameObject towerObj;
        public Vector3 posTower;
        public int currentVersion;

        public TowerContainer(TowerDataSet towerData, TowerPlacement towerPlace, GameObject towerObj, Vector3 posTower, int currentVersion)
        {
            this.towerData = towerData;
            this.towerPlace = towerPlace;
            this.towerObj = towerObj;
            this.posTower = posTower;
            this.currentVersion = currentVersion;
        }
    }
}
