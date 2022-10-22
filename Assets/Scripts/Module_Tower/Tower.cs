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

	private Transform target;
	private EnemyBasic targetEnemy;

	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public Transform firePoint;

	private float fireCountdown = 0f;

	public GameObject bulletPrefab;

	[SerializeField]
	private List<GameObject> towerLevelObject;

	[SerializeField]
	private GameObject towerObjectParent;
	[SerializeField]
	private GameObject towerObject;

	[SerializeField]
	public GameObject circleRange;

	private Animator _animator;

	[HideInInspector]
	public bool isReady;
	public void SetColorRange(Color code)
    {
		SpriteRenderer _circle = circleRange.GetComponent<SpriteRenderer>();
		_circle.color = code;
	}

	public void StartTowerClicked()
    {
		circleRange.SetActive(true);

	}
    public void EndTowerClicked()
    {
		circleRange.SetActive(false);
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

		if (nearestEnemy != null && shortestDistance <= rangeShoot/2)
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
		if (isReady)
        {
			if (target == null)
			{

				return;
			}

			LockOnTarget();

			if (fireCountdown <= 0f)
			{
				if (isReady)
					Shoot();
				fireCountdown = 1f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
		}

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
		_animator = partToRotate.transform.GetChild(1).GetComponent<Animator>();
		_animator.SetTrigger("attack");
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		BulletScript bullet = bulletGO.GetComponent<BulletScript>();
		if (bullet != null)
        {
			bullet.SetBulletData(target, damagePower, stuntDuration, slowDuration);
		}
		BulletAOE bulletaoe = bulletGO.GetComponent<BulletAOE>();
		if (bulletaoe != null)
        {
			bulletaoe.SetBulletData(target, damagePower, stuntDuration, slowDuration);
		}
			
	}

	public void SetCircleRange()
    {
		circleRange.transform.localScale = new Vector3(rangeShoot, rangeShoot, rangeShoot);
	}

	public void SetTowerObject(int index)
    {
		Destroy(towerObject);
		GameObject plant =  Instantiate(towerLevelObject[index - 1], towerObjectParent.transform);
		towerObject = plant;
		SetCircleRange();
	}
}
