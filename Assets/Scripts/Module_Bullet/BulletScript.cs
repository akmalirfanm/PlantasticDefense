using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Enemy;

public class BulletScript : BaseBullet
{
    private EnemyBasic Enemy;
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
                Enemy = other.GetComponent<EnemyBasic>();
                Enemy.GetDamage(damagePower, stuntDuration, slowDuration);
                Destroy(gameObject);
                if (nameOfTower == "basic")
                    EventManager.TriggerEvent("SFXMessage", "Basic Hit");
                else if(nameOfTower == "slow")
                    EventManager.TriggerEvent("SFXMessage", "Slow Hit");
            }
        }
    }
}
