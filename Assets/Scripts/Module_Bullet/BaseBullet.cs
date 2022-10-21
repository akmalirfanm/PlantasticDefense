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

    private float waitTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 3;
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
            WaitDestroy();

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

    private void WaitDestroy()
    {
        waitTime -= Time.deltaTime;
        if(waitTime > 0)
        {
            return;
        }
        Destroy(gameObject);
    }
}
