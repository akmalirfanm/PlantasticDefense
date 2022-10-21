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
        protected float speed;
        protected int resource = 0;
        [SerializeField]
        protected int delay;

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

            transform.LookAt(target);


            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
               
               // Quaternion rot = Quaternion.LookRotation(dir);
               // transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 90);
                GetNextWaypoint();
                

            }
        }
        protected virtual void Update()
        {
            Move();
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
        protected IEnumerator StunEffect(float speedOrigin, float stuntDelay)
        {
            if(stuntDelay > 0)
            {
                speed = 0;
                yield return new WaitForSeconds(stuntDelay);
                speed = speedOrigin;
            }
        }
        protected IEnumerator SlowEffect(float speedOrigin, float slowDelay)
        {

            if(slowDelay > 0)
            {
                Debug.Log("Slowed");

                speed = speed * 0.5f;
                yield return new WaitForSeconds(slowDelay);
                speed = speedOrigin;

                Debug.Log("Slowed DOne  ");
            }
            
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

