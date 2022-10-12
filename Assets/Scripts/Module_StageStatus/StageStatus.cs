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
            //PlayerPrefs.DeleteAll();
        }
        public void DataToSave()
        {
            PlayerPrefs.SetString("Stage Data", JsonUtility.ToJson(stageData));
        }
        public void LoadData()
        {
            stageData = JsonUtility.FromJson<StageList>(PlayerPrefs.GetString("Stage Data"));
        }
    }
}
