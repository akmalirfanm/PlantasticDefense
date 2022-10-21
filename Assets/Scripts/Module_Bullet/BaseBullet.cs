using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    public Transform targetEnemy;
    public float damagePower;
    public float stuntDuration;
    public float slowDuration;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetEnemy != null && targetEnemy.gameObject.activeInHierarchy == true)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy.position, step);
            transform.LookAt(targetEnemy);
        }

        if (targetEnemy == null || targetEnemy.gameObject.activeInHierarchy == false)
        {
            targetEnemy = null;
            var step = speed * Time.deltaTime;
            transform.Translate(Vector3.forward * step);

            /*
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy.position, step);
            transform.LookAt(targetEnemy);*/
        }


    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
