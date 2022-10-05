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
        Spawner spawn;

        [SerializeField]
        private int basicSpeed;
        [SerializeField]
        private int basicHP;
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
            if (Input.GetMouseButtonDown(0))
            {
                basicHP -= 1;
                if (basicHP == 0)
                {
                    /*gameObject.SetActive(false);*/
                    EventManager.TriggerEvent("DieMessage");
                    handle.AddResource(basicResource);
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
        }
    }
}

