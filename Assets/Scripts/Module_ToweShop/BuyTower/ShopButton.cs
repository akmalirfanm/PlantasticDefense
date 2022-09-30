using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plantastic.Module_TowerShop
{
    public class ShopButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField]
        GameObject towerPref;
        [SerializeField]
        int price;
        [SerializeField]
        LayerMask maskLayer;

        bool isRightPlace;
        TowerPlacement _towerPlace;

        GameObject _currentTowerToBuild;

        public void OnBeginDrag(PointerEventData eventData)
        {
            GameObject newTower = Instantiate(towerPref);
            _currentTowerToBuild = newTower;
            TowerFollowMouse();
        }
        public void OnDrag(PointerEventData eventData)
        {
            TowerFollowMouse();
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if(isRightPlace)
            {
                // spent coin -> module Resource
                _towerPlace.BuildTower(towerPref);
            }
            Destroy(_currentTowerToBuild);
            _currentTowerToBuild = null;
        }
        void TowerFollowMouse()
        {
            Camera mainCamera = Camera.main;
            Ray camray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camray, out RaycastHit hitInfo, float.MaxValue, maskLayer))
            {
                _currentTowerToBuild.transform.position = hitInfo.point;
                if (hitInfo.collider.tag == "TowerPlacement" &&
                    hitInfo.collider.GetComponent<TowerPlacement>().isFull == false)
                {
                    isRightPlace = true;
                    _towerPlace = hitInfo.collider.GetComponent<TowerPlacement>();
                }
                else
                    isRightPlace = false;
            }
        }
    }
}

