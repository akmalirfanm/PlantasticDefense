using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyVariant_1 : BaseEnemy
    {
        [SerializeField]
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
        }
        public override void OnDamage()
        {
            if (Input.GetMouseButtonDown(0))
            {
                variant1HP -= 1;
                if (variant1HP == 0)
                {
                    gameObject.SetActive(false);
                    handle.AddResource(variant1Resource);
                    Debug.Log(handle.resource);
                }
            }
        }
    }
}

