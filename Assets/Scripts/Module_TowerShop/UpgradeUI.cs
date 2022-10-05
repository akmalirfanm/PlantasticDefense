using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Plantastic.Module_Resource;

namespace Plantastic.Module_TowerShop
{
    public class UpgradeUI : MonoBehaviour
    {
        [SerializeField] private Button _upButton;
        [SerializeField] private Button _sellButton;
        [SerializeField] private TextMeshProUGUI _upText;
        [SerializeField] private TextMeshProUGUI _sellText;

        [HideInInspector] public int priceSell;
        [HideInInspector] public int priceUpgrade;
        [HideInInspector] public Vector3 posTower;

        private void Awake()
        {
            _upButton.onClick.RemoveAllListeners();
            _upButton.onClick.AddListener(UpButton);
            _sellButton.onClick.RemoveAllListeners();
            _sellButton.onClick.AddListener(SellButton);
        }
        private void OnDestroy()
        {
            _upButton.onClick.RemoveListener(UpButton);
            _sellButton.onClick.RemoveListener(SellButton);
        }
        void UpButton()
        {
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
    }
}

