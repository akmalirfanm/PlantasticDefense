using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Plantastic.Module_PoolingSystem;

namespace Plantastic.Module_Enemy
{
    public abstract class BaseEnemy : MonoBehaviour, IDamageable, IPoolObject
    {
        protected float hp;
        protected int speed;
        protected int resource = 0;

        protected Transform target;
        protected int waypointIndex = 0;

        [SerializeField]
        protected Image healthBarEnemy;

        public PoolingSystem poolingSystem { private set; get; }

        protected virtual void Start()
        {
            target = FindObjectOfType<EnemyWayPoints>().waypoints[0];
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
            OnDamage();
        }
        private void GetNextWaypoint()
        {
            if (waypointIndex >= FindObjectOfType<EnemyWayPoints>().waypoints.Length - 1)
            {
                StoreToPool();
                //gameObject.SetActive(false);
                return;
            }

            waypointIndex++;
            target = FindObjectOfType<EnemyWayPoints>().waypoints[waypointIndex];
        }

        public abstract void OnDamage();

        void IPoolObject.Initial(PoolingSystem poolSystem)
        {
            poolingSystem = poolSystem;
        }

        public abstract void OnCreate();

        public virtual void StoreToPool()
        {
            poolingSystem.Store(this);
            gameObject.SetActive(false);
        }
    }
}

