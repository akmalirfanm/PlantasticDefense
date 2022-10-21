using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_StageStatus
{
    public class StageStatus : MonoBehaviour
    {
        public static StageStatus Instance;

        public StageList stageData;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            DontDestroyOnLoad(gameObject);
            if (PlayerPrefs.HasKey("Stage Data"))
            {
                LoadData();
            }
            else
            {
                DataToSave();
            }
            
        }
        void DataToSave()
        {
            PlayerPrefs.SetString("Stage Data", JsonUtility.ToJson(stageData));
        }
        void LoadData()
        {
            stageData = JsonUtility.FromJson<StageList>(PlayerPrefs.GetString("Stage Data"));
        }

        public void OnGameFinished(string nameScene)
        {
            for(int i = 0; i < stageData.stage.Length; i++)
            {
                if(stageData.stage[i].nameScene == nameScene)
                {
                    stageData.stage[i].unlocked = true;
                    DataToSave();
                }
            }
        }
    }
}
