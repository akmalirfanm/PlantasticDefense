using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Spawner;
using Plantastic.Module_Resource;

namespace Plantastic.Module_Enemy
{
    public class EnemyBasic : BaseEnemy
    {
        public string nameOfEnemy;

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
                //EventManager.TriggerEvent("SFXMessage", "Stun");
                if(nameOfEnemy == "Boss")
                {
                    EventManager.TriggerEvent("SFXMessage", "Boss Death");
                    EventManager.TriggerEvent("OnPlayVfxName", "Boss Dead");
                    Vector3 _pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                    EventManager.TriggerEvent("OnPlayVfxPos", _pos);
                }
                else
                {
                    EventManager.TriggerEvent("SFXMessage", "Death");
                    EventManager.TriggerEvent("OnPlayVfxName", "Enemies Dead");
                    Vector3 _pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                    EventManager.TriggerEvent("OnPlayVfxPos", _pos);
                }
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

