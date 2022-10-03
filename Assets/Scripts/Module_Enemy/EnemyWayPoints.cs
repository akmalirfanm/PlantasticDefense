using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyWayPoints : MonoBehaviour
    {
        public Transform[] waypoints;

        private void Awake()
        {
            waypoints = new Transform[transform.childCount];
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = transform.GetChild(i);
            }
        }
    }
}
