using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_StageList
{
    [CreateAssetMenu(fileName = "New Stage", menuName = "Stage")]
    public class Stage : ScriptableObject
    {
        public string nameStage;
        public int index;
        public Sprite stageImage;
        public bool unlocked;
    }
}
