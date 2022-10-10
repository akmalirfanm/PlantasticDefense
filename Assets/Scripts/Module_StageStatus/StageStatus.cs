using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStatus : MonoBehaviour
{
    public static StageStatus Instance;

    public StageList stageData;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        LoadDataFromScripObj() ;
    }

    public void UnlockStage(int indexStage)
    {
        PlayerPrefs.SetString("stage " + indexStage, "true");
        stageData.stage[indexStage - 1].unlocked = true;
    }
    public void LoadDataFromScripObj()
    {
        for (int i = 1; i <= stageData.stage.Length; i++)
        {
            PlayerPrefs.SetString("stage " + i, stageData.stage[i - 1].unlocked.ToString().ToLower());
        }
    }
}