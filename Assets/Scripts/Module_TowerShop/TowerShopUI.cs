using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Plantastic.Module_Resource;

namespace Plantastic.Module_TowerShop
{
    // handle upgrade, buy UI
    public class TowerShopUI : MonoBehaviour
    {
        [Header("Upgrade")]
        [SerializeField] private Button _upButton;
        [SerializeField] private Button _sellButton;
        [SerializeField] private TextMeshProUGUI _resourceText;
        
        private TextMeshProUGUI _upText;
        private TextMeshProUGUI _sellText;

        [HideInInspector] public int priceUpgrade;
        [HideInInspector] public int priceSell; 

        [HideInInspector] public Vector3 posTower;

        private void Awake()
        {
            _upButton.onClick.RemoveAllListeners();
            _upButton.onClick.AddListener(UpButton);
            _sellButton.onClick.RemoveAllListeners();
            _sellButton.onClick.AddListener(SellButton);

            _upText = _upButton.GetComponentInChildren<TextMeshProUGUI>();
            _sellText = _sellButton.GetComponentInChildren<TextMeshProUGUI>();
        }
        private void Update()
        {
            _resourceText.text = Resource.Instance._totalResource.ToString();
        }
        private void OnDestroy()
        {
            _upButton.onClick.RemoveListener(UpButton);
            _sellButton.onClick.RemoveListener(SellButton);
        }
        void UpButton()
        {
            if(!TowerManager.Instance.UpgradeSetData(posTower))
            {
                return;
            }
            var r = Resource.Instance;
            if (!r.IsResourceEnough(priceUpgrade))
                return;
            r.SpentResource(priceUpgrade);
        }
        void SellButton()
        {
            TowerManager.Instance.RemoveTower(posTower);
            Resource.Instance.AddResource(priceSell);
        }
        public void SetUpText(bool max)
        {
            if (max == true)
                _upText.text = "Max Level";
            else 
                _upText.text = "up : " + priceUpgrade.ToString();

            _sellText.text = "sell : " + priceSell.ToString();
        }
        
    }
}