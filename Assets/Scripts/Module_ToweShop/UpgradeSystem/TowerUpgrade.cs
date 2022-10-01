using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_TowerShop
{
    public class TowerUpgrade : MonoBehaviour
    {
        [SerializeField]
        private GameObject upgradePanel;


        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                CheckClickTower();
            }

        }

        void CheckClickTower()
        {
            Camera mainCamera = Camera.main;
            Ray camray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camray, out RaycastHit click))
            {
                ITowerClicked _click = click.collider.GetComponent<ITowerClicked>();
                if (_click != null)
                {
                    _click.StartTowerClicked();
                    Debug.Log("Tower " + click.collider.gameObject.name + " Clicked");
                    //upgradePanel.SetActive(true);
                }
                else
                {
                    Debug.Log("null");
                }
            }
        }

    }

} 

