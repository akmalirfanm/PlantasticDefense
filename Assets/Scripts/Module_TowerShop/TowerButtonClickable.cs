using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerButtonClickable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject towerDetails;

    public void ShowDetails()
    {
        towerDetails.SetActive(true);
    }
    public void HideDetails()
    {
        towerDetails.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {

        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
}
