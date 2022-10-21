using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Enemy;

public class BulletAOE : BaseBullet
{
    private EnemyBasic Enemy;
    private bool AOEEnabled;
    [SerializeField]
    private AOEEffect aoeEffect; 
    public void SetBulletData(Transform target, float damage, float stunt, float slow)
    {
        targetEnemy = target;
        damagePower = damage;
        stuntDuration = stunt;
        slowDuration = slow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetEnemy != null)
        {
            if (other.gameObject == targetEnemy.gameObject)
            {
                other.GetComponent<EnemyBasic>().GetDamage(0, stuntDuration, 0);
                aoeEffect.GetComponent<AOEEffect>().StartAOEEffect(damagePower, 0, slowDuration);
            }
        }
    }
}
