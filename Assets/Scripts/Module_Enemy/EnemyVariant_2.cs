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
        private int variant2HP;
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
                variant2HP -= 1;
                if (variant2HP == 0)
                {
                    /*gameObject.SetActive(false);*/
                    StoreToPool();
                    handle.AddResource(variant2Resource);
                    Debug.Log(handle.resource);
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
        }
    }
}

