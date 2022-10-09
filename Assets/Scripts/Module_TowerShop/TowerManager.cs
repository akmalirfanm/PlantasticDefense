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
                TowerContainer newTower = new TowerContainer(a[i], null, a[i].transform.position, 0, 0);
                towerList.Add(newTower);
            }
            Resource.Instance.AddResource(400);
        }

        #region New Tower
        public void BuildNewTower(GameObject tower, Vector3 pos)
        {
            var r = Resource.Instance;
            if (!r.IsResourceEnough(tower.GetComponent<Tower>().price))
            {
                return;
            }
            r.SpentResource(tower.GetComponent<Tower>().price);

            GameObject _newTower = Instantiate(tower, pos, Quaternion.identity);
            Tower _baseTower = _newTower.GetComponent<Tower>();

            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));
            var i = towerList.IndexOf(_tower);
            _tower = new(_tower.towerPlace, _newTower, pos, _baseTower.price, 1);
            towerList[i] = _tower;

        }
        #endregion

        #region Upgrade Tower
        public void InitialUpgradeData(Vector3 pos)
        {
            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));
            
            _shopUI.priceSell = CalculateSellingPrice(_tower.price);
            _shopUI.priceUpgrade = CalculateUpgradePrice(_tower.price);
            _shopUI.posTower = _tower.posTower;
        }
        private int CalculateSellingPrice(int price)
        {
            price = Mathf.RoundToInt(price - (price * 50 / 100));
            return price;
        }
        public int CalculateUpgradePrice(int price)
        {
            price = Mathf.RoundToInt(price + (price * 50 / 100));
            return price;
        }
        public void RemoveTower(Vector3 pos)
        {
            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));
            var i = towerList.IndexOf(_tower);
            Destroy(towerList[i].towerObj);
            _tower = new(_tower.towerPlace, null, pos, _tower.price, 1);
            towerList[i] = _tower;

            _tower.towerPlace.isFull = false;
            _upgrade.HideUpgradePanel();
        }
        #endregion 
    }
}

