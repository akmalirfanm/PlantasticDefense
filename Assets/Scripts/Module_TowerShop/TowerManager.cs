using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Resource;

namespace Plantastic.Module_TowerShop
{
    public class TowerManager : MonoBehaviour
    {
        public static TowerManager Instance;

        [SerializeField] private UpgradeUI _upgradeUI;

        List<TowerContainer> towerList = new List<TowerContainer>();
        List<TowerPlacement> _towerPlace = new List<TowerPlacement>();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        private void Start()
        {
            _towerPlace.AddRange(FindObjectsOfType<TowerPlacement>());
        }

        #region New Tower
        public void BuildNewTower(GameObject tower, Vector3 pos)
        {
            var r = Resource.Instance;
            if (!r.IsResourceEnough(tower.GetComponent<BaseTower>().price))
            {
                return;
            }
            r.SpentResource(tower.GetComponent<BaseTower>().price);

            GameObject _newTower = Instantiate(tower, pos, Quaternion.identity);
            BaseTower _tower = _newTower.GetComponent<BaseTower>();
            TowerContainer _towerData = new TowerContainer(_newTower, pos, _tower.price, 1);
            towerList.Add(_towerData);
        }
        #endregion

        #region Upgrade Tower
        public void InitialUpgradeData(Vector3 pos)
        {
            TowerContainer _tower = towerList.Find(x => (x.posTower.x == pos.x) && (x.posTower.z == pos.z));

            _upgradeUI.priceSell = CalculateSellingPrice(_tower.price);
            _upgradeUI.priceUpgrade = CalculateUpgradePrice(_tower.price);
            _upgradeUI.posTower = _tower.posTower;
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
            Destroy(_tower.towerObj);
            towerList.Remove(_tower);

            TowerPlacement _place = _towerPlace.Find(x => (x.transform.position.x == pos.x) && (x.transform.position.z == pos.z));
            _place.isFull = false;
        }
        #endregion 
    }
}

