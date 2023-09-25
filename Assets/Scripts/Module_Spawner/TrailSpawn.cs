using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Enemy;

namespace Plantastic.Module_Spawner
{
    public class TrailSpawn : MonoBehaviour
    {
        private Transform target;
        private int waypointIndex = 0;
        private float speed = 5;
        private void Start()
        {
            target = FindObjectOfType<EnemyWayPoints>().waypoints[0];
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            transform.LookAt(target);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }
        }
        private void GetNextWaypoint()
        {
            waypointIndex++;
            if (waypointIndex >= FindObjectOfType<EnemyWayPoints>().waypoints.Length - 1)
            {
                gameObject.SetActive(false);
            }
            target = FindObjectOfType<EnemyWayPoints>().waypoints[waypointIndex];
        }
    }
}

