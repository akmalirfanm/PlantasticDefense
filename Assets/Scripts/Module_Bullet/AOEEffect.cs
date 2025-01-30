using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_Enemy;

public class AOEEffect : MonoBehaviour
{
    private EnemyBasic Enemy;
    private bool AOEEnabled;

    public float damagePower;
    public float stuntDuration;
    public float slowDuration;
    // Start is called before the first frame update
    

    public void StartAOEEffect(float damage, float stunt, float slow)
    {
        damagePower = damage;
        stuntDuration = stunt;
        slowDuration = slow;
        AOEEnabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (AOEEnabled)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Enemy = other.GetComponent<EnemyBasic>();
                Enemy.GetDamage(damagePower, stuntDuration, slowDuration);
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
