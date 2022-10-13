using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyVariant_3 : BaseEnemy
    {
        ResourceHandle handle;

        [SerializeField]
        private int variant3Speed;
        [SerializeField]
        private float variant3HP;
        [SerializeField]
        private int variant3Resource;
        protected override void Start()
        {
            base.Start();
            speed += variant3Speed;
            hp += variant3HP;

            handle = FindObjectOfType<ResourceHandle>();
        }
        public override void OnDamage()
        {
            if (Input.GetMouseButtonDown(0))
            {
                hp -= 1;
                healthBarEnemy.fillAmount = hp / variant3HP;
                if (hp <= 0)
                {
                    /*gameObject.SetActive(false);*/
                    EventManager.TriggerEvent("SFXMessage", "SFX_Test");
                    handle.AddResource(variant3Resource);
                    healthBarEnemy.fillAmount = variant3HP;
                    Debug.Log(handle.resource);
                    StoreToPool();
                }
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
            hp = variant3HP;
        }
    }
}

