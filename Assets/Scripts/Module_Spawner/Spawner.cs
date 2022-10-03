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

        private float delaySpawn = 3f;
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
					yield return new WaitForSeconds(0.5f);
				}
				waveIndex++;
			}
			
        }
		void SpawnEnemy()
        {
            int _random = Random.Range(0, controlls.Length);
			int _weakEnemy = Random.Range(0, controlls.Length-2);
			int _strongEnemy = Random.Range(0, controlls.Length-1);

			if (waveIndex <= 4)
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
			else
            {
				controlls[_random].CreateObject(transform.position);
			}
        }
    }

}
