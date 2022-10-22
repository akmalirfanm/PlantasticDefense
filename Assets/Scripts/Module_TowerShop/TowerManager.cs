using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Resource;

namespace Plantastic.Module_TowerShop
{
    public class TowerManager : MonoBehaviour
    {
        public static TowerManager Instance;

        [SerializeField] private TowerShopUI _shopUI;
        [SerializeField] private UpgradeClick _upgrade;

        List<TowerContainer> towerList = new List<TowerContainer>();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        private void Start()
        {
            var a = FindObjectsOfType<TowerPlacement>();
            for(int i = 0; i < a.Length; i++)
            {
                TowerContainer newTower = new TowerContainer(null,a[i], null, a[i].transform.position, 0);
                towerList.Add(newTower);
            }
        }

        #region New Tower
        public void BuildNewTower(GameObject tower, Vector3 pos, TowerDataSet towerData)
        {
            var r = Resource.Instance;
            if (!r.IsResourceEnough(towerData.version[0].price))
            {
                return;
            }
            r.SpentResource(towerData.version[0].price);

            GameObject _newTower = Instantiate(tower, pos, Quaternion.identity);
            SetDataTower(pos, towerData, _newTower);

            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));
            int i = towerList.IndexOf(_tower);
            
            _tower = new(towerData, _tower.towerPlace, _newTower, pos, 1);
            towerList[i] = _tower;
            towerList[i].towerObj.GetComponent<Tower>().isReady = true;
        }
        #endregion

        public void InitialUpgradeData(Vector3 pos)
        {
            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));
            int i = towerList.IndexOf(_tower);

            // set properties upgrade UI
            var v = towerList[i].towerData.version;
            _shopUI.priceSell = v[towerList[i].currentVersion-1].priceSell;
            _shopUI.posTower = towerList[i].posTower;
            if(v.Length <= towerList[i].currentVersion)
            {
                _shopUI.SetUpText(true);
                return;
                
            }
            _shopUI.priceUpgrade = v[towerList[i].currentVersion].price;
            _shopUI.SetUpText(false);

        }

        #region Set Data Tower
        public void RemoveTower(Vector3 pos)
        {
            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));
            int i = towerList.IndexOf(_tower);
            Destroy(towerList[i].towerObj);

            _tower.towerPlace.isFull = false;
            _tower.currentVersion = 0;
            towerList[i] = _tower;

            _upgrade.HideUpgradePanel();
        }

        void SetDataTower(Vector3 pos, TowerDataSet data, GameObject towerObj)
        {
            // find the tower 
            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));
            int i = towerList.IndexOf(_tower);

            // replace data container tower
            _tower = new(data, _tower.towerPlace, towerObj, pos, _tower.currentVersion + 1);

            // set properties tower it selft
            var d = data.version[_tower.currentVersion - 1];
            var t = _tower.towerObj.GetComponent<Tower>();
            t.fireRate = d.fireRate;
            t.rangeShoot = d.rangeShoot;
            t.damagePower = d.damagePower;
            t.stuntDuration = d.stuntDuration;
            t.slowDuration = d.slowDuration;
            
            //restore data to tower list
            towerList[i] = _tower;

            // set model of prefab
            towerList[i].towerObj.GetComponent<Tower>().SetTowerObject(towerList[i].currentVersion);

            InitialUpgradeData(pos);
        }
 
        public bool UpgradeSetData(Vector3 pos)
        {
            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));
            int i = towerList.IndexOf(_tower);
            var t = towerList[i];

            if (_tower.currentVersion >= t.towerData.version.Length)
            {
                return false;
            }
            SetDataTower(pos, t.towerData, t.towerObj);
            return true;
        }
        #endregion
    }
}

