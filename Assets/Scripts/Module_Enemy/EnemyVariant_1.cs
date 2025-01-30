using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyVariant_1 : BaseEnemy
    {
        ResourceHandle handle;

        [SerializeField]
        private int variant1Speed;
        [SerializeField]
        private float variant1HP;
        [SerializeField]
        private int variant1Resource;
        protected override void Start()
        {
            base.Start();
            speed += variant1Speed;
            hp += variant1HP;

            handle = FindObjectOfType<ResourceHandle>();
        }
        public override void OnDamage()
        {
            if (Input.GetMouseButtonDown(0))
            {
                hp -= 1;
                healthBarEnemy.fillAmount = hp / variant1HP;
                if (hp <= 0)
                {
                    /*gameObject.SetActive(false);*/
                    EventManager.TriggerEvent("SFXMessage", "SFX_Test");
                    handle.AddResource(variant1Resource);
                    Debug.Log(handle.resource);
                    healthBarEnemy.fillAmount = variant1HP;
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
            hp = variant1HP;
        }
    }
}

