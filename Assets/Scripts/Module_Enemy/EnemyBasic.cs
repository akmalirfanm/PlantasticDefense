using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyBasic : BaseEnemy
    {
        [SerializeField]
        ResourceHandle handle;

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
        }
        public override void OnDamage()
        {
            if (Input.GetMouseButtonDown(0))
            {
                basicHP -= 1;
                if (basicHP == 0)
                {
                    gameObject.SetActive(false);
                    handle.AddResource(basicResource);
                    Debug.Log(handle.resource);
                }
            }
        }
    }
}

