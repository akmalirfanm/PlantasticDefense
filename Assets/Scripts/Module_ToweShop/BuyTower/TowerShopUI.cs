using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_TowerShop
{
    public class TowerShopUI : MonoBehaviour
    {
        void CheckClickTower()
        {
            Camera mainCamera = Camera.main;
            Ray camray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camray, out RaycastHit click))
            {
                ITowerClicked _click = click.collider.GetComponent<ITowerClicked>();
                if (_click != null)
                {
                    _click.TowerClicked();
                }
                else
                {

                }
            }
        }
        private void Update()
        {
            CheckClickTower();
        }
    }

} 

