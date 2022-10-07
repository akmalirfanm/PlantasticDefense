using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_StageStatus
{
    public class StageStatus : MonoBehaviour
    {
        public static StageStatus Instance;

        List<>

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            DontDestroyOnLoad(this);
        }

        public void SaveDataStage()
        {

        }
        public void LoadDataStage()
        {

        }
    }
}
