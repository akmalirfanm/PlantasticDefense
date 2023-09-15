using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Spawner;
using Plantastic.Module_Resource;

namespace Plantastic.Module_Enemy
{
    public class EnemyBasic : BaseEnemy
    {
        ResourceHandle handle;

        [SerializeField]
        private float basicSpeed;
        [SerializeField]
        private float basicHP;
        [SerializeField]
        private int basicResource;
        protected override void Start()
        {
            base.Start();
            speed += basicSpeed;
            hp += basicHP;

            handle = FindObjectOfType<ResourceHandle>();
        }
        public override void OnDamage()
        {
           
        }

        public void GetDamage(float damage, float stunt, float slow)
        {
            hp -= damage;
            StartCoroutine(StunEffect(basicSpeed, stunt));
            StartCoroutine(SlowEffect(basicSpeed, slow));
            healthBarEnemy.fillAmount = hp / basicHP;
            if (hp <= 0)
            {
                EventManager.TriggerEvent("EnemyDie", null);
                speed = basicSpeed;
                EventManager.TriggerEvent("SFXMessage", "Stun");
                Resource.Instance.AddResource(basicResource);
                healthBarEnemy.fillAmount = basicHP;
                StoreToPool();
            }
        }

        public override void OnCreate()
        {
            EventManager.TriggerEvent("AddEnemySpawnCount");
            waypointIndex = 0;
            target = FindObjectOfType<EnemyWayPoints>().waypoints[0];
        }
        public override void StoreToPool()
        {
            base.StoreToPool();
            hp = basicHP;
        }
    }
}

