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
        [SerializeField] private float speed = 5f;

        private EnemyWayPoints enemyWayPoints;

        private void Start()
        {
            enemyWayPoints = FindObjectOfType<EnemyWayPoints>();

            if (enemyWayPoints == null || enemyWayPoints.waypoints.Length == 0)
            {
                Debug.LogWarning("EnemyWayPoints not found or has no waypoints!");
                enabled = false;
                return;
            }

            target = enemyWayPoints.waypoints[waypointIndex];
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (target == null) return;

            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            transform.LookAt(target);

            if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            {
                GetNextWaypoint();
            }
        }

        private void GetNextWaypoint()
        {
            waypointIndex++;

            if (waypointIndex >= enemyWayPoints.waypoints.Length)
            {
                gameObject.SetActive(false);
                return;
            }

            target = enemyWayPoints.waypoints[waypointIndex];
        }
    }
}
