using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Plantastic.Module_TowerShop
{
    public class UpgradeClick : MonoBehaviour
    {
        [SerializeField] private GameObject _upgradePanel;
        [SerializeField] private Button _overlayButton;

        private ITowerClicked _tempClick;
        private bool isAnyTowerClicked;

        private void Awake()
        {
            _overlayButton.onClick.AddListener(HideUpgradePanel);
        }
        private void Start()
        {
           _tempClick = null;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isAnyTowerClicked)
            {
                if (!CheckClickTower())
                {
                    HideUpgradePanel();
                }
            }
        }
        bool CheckClickTower()
        {
            Camera mainCamera = Camera.main;
            var camray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camray, out RaycastHit click))
            {
                ITowerClicked _click = click.collider.GetComponent<ITowerClicked>();
                if (_click != null)
                {
                    _click.StartTowerClicked();
                    _tempClick = click.collider.GetComponent<ITowerClicked>();

                    _upgradePanel.SetActive(true);
                    TowerManager.Instance.InitialUpgradeData(click.collider.gameObject.transform.position);

                    isAnyTowerClicked = true;
                    return true;
                }
            }
            _tempClick = null;
            return false;
        }
        public void HideUpgradePanel()
        {
            _upgradePanel.SetActive(false);
            isAnyTowerClicked = false;
            if(_tempClick != null)
                _tempClick.EndTowerClicked();
        }

    }

}

