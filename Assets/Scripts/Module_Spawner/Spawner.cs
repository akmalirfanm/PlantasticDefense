using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;
using Plantastic.Module_Enemy;

namespace Plantastic.Module_Spawner
{
    public class Spawner : MonoBehaviour
    {
        private int enemyAlive;

        [SerializeField]
        EnemyControll[] controlls;

        [SerializeField]
        private Transform spawnPoint;

        private float delaySpawn = 5f;
        private float countdown = 3f;

        private int waveIndex = 0;

		void Update()
		{
			if (enemyAlive > 0)
			{
				return;
			}

			if (waveIndex == controlls.Length)
			{
				this.enabled = false;
			}

			if (countdown <= 0f)
			{
				StartCoroutine(SpawnWave());
				countdown = delaySpawn;
				return;
			}

			countdown -= Time.deltaTime;

			countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
		}
		IEnumerator SpawnWave()
        {
			EnemyControll controll = controlls[waveIndex];

			enemyAlive = controll.count;

			for (int i=0; i<controll.count; i++)
            {
				yield return new WaitForSeconds(1f / controll.rate);
            }
			waveIndex++;
        }
		void SpawnEnemy()
        {

        }
	}

}
