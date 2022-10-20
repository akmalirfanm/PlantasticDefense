  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_TowerShop;
using Plantastic.Module_Enemy;

public class Tower : MonoBehaviour, ITowerClicked
{
    public float fireRate;
    public float rangeShoot;
    public float damagePower;

    public float stuntDuration;
    public float slowDuration;

	public LineRenderer lineRenderer;
	private Transform target;
	private EnemyBasic targetEnemy;

	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public Transform firePoint;

	private float fireCountdown = 0f;

	public GameObject bulletPrefab;

	public void StartTowerClicked()
    {

    }
    public void EndTowerClicked()
    {

    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= rangeShoot)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<EnemyBasic>();
		}
		else
		{
			target = null;
		}

	}

	void Update()
	{
		if (target == null)
		{

			return;
		}

		LockOnTarget();

		if (fireCountdown <= 0f)
		{
			Shoot();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;

	}

	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Shoot()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		BulletScript bullet = bulletGO.GetComponent<BulletScript>();
		if (bullet != null)
			bullet.SetBulletData(target, damagePower, stuntDuration, slowDuration);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, rangeShoot);
	}
}
