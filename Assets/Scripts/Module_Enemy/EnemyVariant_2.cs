using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyVariant_2 : BaseEnemy
    {
        ResourceHandle handle;

        [SerializeField]
        private int variant2Speed;
        [SerializeField]
        private float variant2HP;
        [SerializeField]
        private int variant2Resource;
        protected override void Start()
        {
            base.Start();
            speed += variant2Speed;
            hp += variant2HP;

            handle = FindObjectOfType<ResourceHandle>();
        }
        public override void OnDamage()
        {
            if (Input.GetMouseButtonDown(0))
            {
                hp -= 1;
                healthBarEnemy.fillAmount = hp / variant2HP;
                if (hp <= 0)
                {
                    /*gameObject.SetActive(false);*/
                    EventManager.TriggerEvent("SFXMessage", "SFX_Test");
                    handle.AddResource(variant2Resource);
                    healthBarEnemy.fillAmount = variant2HP;
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
            hp = variant2HP;
        }
    }
}

