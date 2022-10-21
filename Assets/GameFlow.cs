using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField]
    private int EnemyCounter;

    [SerializeField]
    private int EnemySpawnedCounter;

    [SerializeField]
    private int totalWave;

    [SerializeField]
    private int currentWave;

    [SerializeField]
    private float playerHP;

    private void OnEnable()
    {
        EventManager.StartListening("AddEnemyCount", AddEnemyCount);
        EventManager.StartListening("AddEnemySpawnCount", AddSpawnedEnemyCount);
        EventManager.StartListening("CheckWinLose", CheckWinLoseCondition);
        EventManager.StartListening("DecreaseHP", DecreaseHp);
    }
    private void OnDisable()
    {
        EventManager.StopListening("AddEnemyCount", AddEnemyCount);
        EventManager.StopListening("AddEnemySpawnCount", AddSpawnedEnemyCount);
        EventManager.StopListening("CheckWinLose", CheckWinLoseCondition);
        EventManager.StopListening("DecreaseHP", DecreaseHp);
    }

    private void Update()
    {
        
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

    public void SetCurrentWave(int index)
    {
        currentWave = index;
    }

    private void CheckWinLoseCondition()
    {
        if (currentWave == totalWave)
        {
            CheckWin();
        }

        if(playerHP <= 0)
        {
            SetLose();
        }
    }

    private void CheckWin()
    {
        if(EnemyCounter >= EnemySpawnedCounter && playerHP > 0)
        {
            SetWin();
        }
    }

    private void SetLose()
    {
        Debug.Log("LOSER");
    }

    private void SetWin()
    {
        Debug.Log("WINNER");
    }

    private void DecreaseHp(object data)
    {
        float hp = (float)data;
        playerHP -= hp;
    }
}
