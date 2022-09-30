using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyVariant_3 : BaseEnemy
    {
        [SerializeField]
        ResourceHandle handle;

        [SerializeField]
        private int variant3Speed;
        [SerializeField]
        private int variant3HP;
        [SerializeField]
        private int variant3Resource;
        protected override void Start()
        {
            base.Start();
            speed += variant3Speed;
            hp += variant3HP;
        }
        public override void OnDamage()
        {
            if (Input.GetMouseButtonDown(0))
            {
                variant3HP -= 1;
                if (variant3HP == 0)
                {
                    gameObject.SetActive(false);
                    handle.AddResource(variant3Resource);
                    Debug.Log(handle.resource);
                }
            }
        }
    }
}

