using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        protected int hp = 1;

        [SerializeField]
        protected int speed;
        protected int resource = 30;

        protected Transform target;
        protected int waypointIndex = 0;

        [SerializeField]
        protected EnemyWayPoints _wayPoints;

        protected virtual void Start()
        {
            target = _wayPoints.waypoints[0];
        }

        protected virtual void Move()
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }
        }
        protected virtual void Update()
        {
            Move();
        }
        private void GetNextWaypoint()
        {
            if (waypointIndex >= _wayPoints.waypoints.Length - 1)
            {
                gameObject.SetActive(false);
                return;
            }

            waypointIndex++;
            target = _wayPoints.waypoints[waypointIndex];
        }
    }
}

