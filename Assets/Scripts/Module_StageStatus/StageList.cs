using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_StageStatus
{
    [System.Serializable]
    public class StageList
    {
        public Stage[] stage;
    }

    [System.Serializable]
    public class Stage
    {
        public string name;
        public bool unlocked;
    }
}

