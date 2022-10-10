using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower Data")]
public class TowerDataBundle : ScriptableObject
{
    public string nameOfTower;
    public Version[] version;
}

[System.Serializable]
public class Version
{
    public int price;
    public int fireRate;
    public float rangeShoot;
}
