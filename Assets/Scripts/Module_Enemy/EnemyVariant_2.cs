using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyVariant_2 : BaseEnemy
    {
        [SerializeField]
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
        }
        public override void OnDamage()
        {
            if (Input.GetMouseButtonDown(0))
            {
                variant2HP -= 1;
                if (variant2HP == 0)
                {
                    gameObject.SetActive(false);
                    handle.AddResource(variant2Resource);
                    Debug.Log(handle.resource);
                }
            }
        }
    }
}

