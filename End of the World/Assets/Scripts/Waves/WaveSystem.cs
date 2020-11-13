using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
	public State state;

	[SerializeField] private List<Wave> waves;
	[SerializeField] private GameObject upgradeMenu;

	private Wave currentWave;
	private Vector2 screenBounds;

	private int waveIndex;
	private int enemyIndex;

	// Start is called before the first frame update
	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

		waves = new List<Wave>();
		waveIndex = 0;
		enemyIndex = 0;

		foreach (Transform child in transform)
		{
			Wave wave = child.gameObject.GetComponent<Wave>();
			// Check if Wave contains Wave class
			if (!waves.Contains(wave))
			{
				waves.Add(wave);
			}
		}

		StartNextWave();
	}

	// Spawns enemies 
	IEnumerator EnemySpawning()
	{
		while (true)
		{
			if (state == State.InBattle)
			{
				yield return new WaitForSeconds(currentWave.spawnTime);
				SpawnEnemy();

				if (currentWave.enemyCount <= 0)
				{
					if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
					{
						Debug.Log("End of Wave");
						// End of wave
						state = State.Upgrading;
						currentWave.isWaveDone = true;

						// Open Upgrade Menu
						upgradeMenu.SetActive(true);

						yield break;
					}
				}
			}
		}
	}

	private void SpawnEnemy()
	{
		if(currentWave.enemies.Count > 0)
		{
			Debug.Log("Spawning Enemy");

			var enemy = currentWave.enemies[0];
			currentWave.enemies.Remove(enemy);

			GameObject newEnemy = Instantiate(enemy) as GameObject;
			newEnemy.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
		}
	}

	// Start next wave when done upgrading
	public void StartNextWave()
	{
		Debug.Log("Next Wave");
		currentWave = waves[waveIndex];
		waveIndex++;
		state = State.InBattle;
		upgradeMenu.SetActive(false);

		// Start wave spawning
		StartCoroutine(EnemySpawning());
	}
}

public enum State
{
	InBattle,
	Upgrading,
	Paused
}