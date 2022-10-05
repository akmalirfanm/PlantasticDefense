using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_TowerShop;

public abstract class BaseTower : MonoBehaviour, ITowerClicked
{
    public int price;
    public int fireRate;
    public float rangeShoot;

    public abstract void EndTowerClicked();

    public abstract void StartTowerClicked();
}
