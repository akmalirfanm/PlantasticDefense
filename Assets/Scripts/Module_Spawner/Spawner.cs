using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

		[SerializeField]
		TextMeshProUGUI waveText;

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
					StartCoroutine(WaveSpawnText(waveIndex));
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
		IEnumerator WaveSpawnText(int i)
        {
			waveText.gameObject.SetActive(true);
			waveText.text = "WAVE : " + i;
			yield return new WaitForSeconds(1f);
			waveText.gameObject.SetActive(false);
		}
    }

}
