using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField]
    private Transform spawnBulletPos;

    [SerializeField]
    private GameObject bulletFabs;

    [SerializeField]
    private float cooldownTime;
    private float _cooldownTimeSave;


    private GameObject other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;

                if (curDistance <= 15)
                {

                    Vector3 dir = go.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    other = go;

                    spawnBul();
                }
            }
        }
        return closest;
    }

    public void spawnBul()
    {
        _cooldownTimeSave -= Time.deltaTime;
        if (_cooldownTimeSave > 0) return;

        _cooldownTimeSave = cooldownTime;



        //instantiate bult with closest enemy
        /*
        Instantiate(bullet, posBullet.transform.position, Quaternion.identity);
        bullet.GetComponent<misilleScript>().target = other;

        */
    }
}
