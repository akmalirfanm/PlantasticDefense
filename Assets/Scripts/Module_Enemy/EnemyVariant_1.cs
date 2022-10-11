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
        private int variant1HP;
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
                if (hp <= 0)
                {
                    /*gameObject.SetActive(false);*/
                    handle.AddResource(variant1Resource);
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
            hp = variant1HP;
        }
    }
}

