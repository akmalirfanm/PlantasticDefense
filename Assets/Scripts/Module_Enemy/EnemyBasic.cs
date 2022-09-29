using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class EnemyBasic : BaseEnemy, IDamageable
    {
        protected override void Start()
        {
            base.Start();
            speed += 10;
        }

        public void OnDamage()
        {
            
        }
    }
}

