using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageList : ScriptableObject
{
    public Stage[] stage;
}

[System.Serializable]
public class Stage
{
    public bool unlocked;
}
