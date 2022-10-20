using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;
using Plantastic.Module_Enemy;

namespace Plantastic.Module_Spawner
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField]
        EnemyControll[] controlls;
		[SerializeField]
		BulletControlls[] bulletControlls;

		[SerializeField]
        private float delaySpawn;
        private float countdown = 1f;

        private int waveIndex = 1;
		[SerializeField]
		private int totalWave;

		void Update()
		{

			/*if (waveIndex == controlls.Length)
			{
				this.enabled = false;
			}*/
			
			if (countdown <= 0f)
			{
				StartCoroutine(SpawnWave());
				StartCoroutine(SpawnBullet());
				countdown = delaySpawn;
			}

			countdown -= Time.deltaTime;

			countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
		}
		IEnumerator SpawnWave()
        {
			if (totalWave >= waveIndex)
            {
				for (int i = 0; i < waveIndex; i++)
				{
					SpawnEnemy();
					yield return new WaitForSeconds(1f);
				}
				waveIndex++;
			}
			
        }
		void SpawnEnemy()
        {
            int _random = Random.Range(0, controlls.Length);
			int _weakEnemy = Random.Range(0, controlls.Length-2);
			int _strongEnemy = Random.Range(0, controlls.Length-1);

			if (waveIndex <= 3)
            {
				controlls[0].CreateObject(transform.position);
            }
			else if (waveIndex <= 8)
            {
				controlls[_weakEnemy].CreateObject(transform.position);
			}
			else if (waveIndex <= 12)
            {
				controlls[_strongEnemy].CreateObject(transform.position);
			}
			else if (waveIndex == 13)
            {
				waveIndex = 1;
				controlls[controlls.Length-1].CreateObject(transform.position);
				waveIndex = 14;
			}
        }
		IEnumerator SpawnBullet()
        {
			yield return new WaitForSeconds(.5f);
			//index parameter diisi data tower dari scriptable object tower mana yang dibeli
			bulletControlls[0].CreateObject(transform.position);
		}
    }

}
