using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower Data")]
public class TowerDataSet : ScriptableObject
{
    public string nameOfTower;
    public Version[] version;
}

[System.Serializable]
public class Version
{
    public int price;
    public int priceSell;

    public int fireRate;
    public float rangeShoot;
    public float damagePower;

    public float stuntDuration;
    public float slowDuration;
}
