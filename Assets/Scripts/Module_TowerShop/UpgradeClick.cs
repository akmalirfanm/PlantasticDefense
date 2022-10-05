using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_TowerShop
{
    public class UpgradeClick : MonoBehaviour
    {
        [SerializeField] private GameObject _upgradePanel;

        private ITowerClicked tempClick;
        private void Start()
        {
            tempClick = null;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!CheckClickTower())
                {
                    if(tempClick != null)
                    {
                        tempClick.EndTowerClicked();
                        _upgradePanel.SetActive(false);
                    }
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
                    tempClick = click.collider.GetComponent<ITowerClicked>();

                    _upgradePanel.SetActive(true);
                    TowerManager.Instance.InitialUpgradeData(click.collider.gameObject.transform.position);
                    return true;
                }
            }
            tempClick = null;
            return false;
        }

    }

}

