using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField]
    private int EnemyCounter;

    [SerializeField]
    private int EnemySpawnedCounter;

    [SerializeField]
    private int totalWave;

    private void OnEnable()
    {
        EventManager.StartListening("AddEnemyCount", AddEnemyCount);
    }
    private void OnDisable()
    {
        EventManager.StopListening("AddEnemyCount", AddEnemyCount);
    }

    public void AddSpawnedEnemyCount()
    {
        EnemySpawnedCounter += 1;
    }

    public void AddEnemyCount(object count)
    {
        EnemyCounter += 1;
    }

    public void SetTotalWave(int total)
    {
        totalWave = total;
    }
}
