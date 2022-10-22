using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField]
    private GameScene gamescene;

    [SerializeField]
    private TextMeshProUGUI resultText;

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
        if (currentWave >= totalWave)
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
        gamescene.GetComponent<GameScene>().ShowResult("lose");
        resultText.text = "DEFEAT";
        EventManager.TriggerEvent("SFXMessage", "Lose");
    }

    private void SetWin()
    {
        gamescene.GetComponent<GameScene>().ShowResult("win");
        resultText.text = "VICTORY";
        EventManager.TriggerEvent("SFXMessage", "Win");
    }

    private void DecreaseHp(object data)
    {
        float hp = (float)data;
        playerHP -= hp;
        EventManager.TriggerEvent("UpdateHP", playerHP);
    }
}
