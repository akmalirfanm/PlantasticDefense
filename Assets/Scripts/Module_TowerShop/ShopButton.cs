using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace Plantastic.Module_TowerShop
{
    public class ShopButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private GameObject towerPref;
        [SerializeField] private TowerDataSet towerData;
        [SerializeField] private LayerMask placeLayer;
        [SerializeField] private string tagTowerPlacement = "TowerPlacement";

        private TextMeshProUGUI priceText; 
        private bool isRightPlace;
        private TowerPlacement _towerPlace;
        private GameObject _currentTowerToBuild;
        

        private void Awake()
        {
            priceText = GetComponentInChildren<TextMeshProUGUI>();
            priceText.text = towerData.version[0].price.ToString();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _currentTowerToBuild = Instantiate(towerPref);
            TowerFollowMouse();
        }
        public void OnDrag(PointerEventData eventData)
        {
            TowerFollowMouse();
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (isRightPlace)
            {
                _towerPlace.BuildTower(towerPref, towerData); 
            }
            Destroy(_currentTowerToBuild);
            _currentTowerToBuild = null;
        }
        void TowerFollowMouse()
        {
            Camera mainCamera = Camera.main;
            Ray camray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camray, out RaycastHit hitInfo, float.MaxValue, placeLayer))
            {
                _currentTowerToBuild.transform.position = hitInfo.point;
                if (hitInfo.collider.tag == tagTowerPlacement &&
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
