using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Spawner;

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
            Debug.Log(hp / basicHP);
            hp -= damage;
            StartCoroutine(StunEffect(basicSpeed, stunt));
            StartCoroutine(SlowEffect(basicSpeed, slow));
            healthBarEnemy.fillAmount = hp / basicHP;
            Debug.Log(hp / basicHP);
            if (hp <= 0)
            {
                speed = basicSpeed;
                /*gameObject.SetActive(false);*/
                EventManager.TriggerEvent("SFXMessage", "SFX_Test");
                handle.AddResource(basicResource);
                Debug.Log(handle.resource);
                healthBarEnemy.fillAmount = basicHP;
                StoreToPool();
            }
        }

        public override void OnCreate()
        {
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

