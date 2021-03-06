﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
	[SerializeField] public static State state;

	[SerializeField] private List<Wave> waves;
	[SerializeField] private GameObject upgradeMenu;
	[SerializeField] private GameObject bossPrefab;
	[SerializeField] private LevelLoader levelLoader;

	private Wave currentWave;
	private Vector2 screenBounds;

	private int waveIndex;

	// Start is called before the first frame update
	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

		waves = new List<Wave>();
		waveIndex = 0;

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
					if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
					{
						Debug.Log("End of Wave");
						// End of wave
						state = State.Upgrading;

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
			var enemy = currentWave.enemies[0];
			currentWave.enemies.Remove(enemy);

			GameObject newEnemy = Instantiate(enemy) as GameObject;
			newEnemy.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
		}
	}

	// Start next wave when done upgrading
	public void StartNextWave()
	{
		try
		{
			Debug.Log("Next Wave");
			currentWave = waves[waveIndex];
			waveIndex++;
			state = State.InBattle;
			upgradeMenu.SetActive(false);

			// Start wave spawning
			StartCoroutine(EnemySpawning());
		}
		catch (System.Exception)
		{
			Debug.Log("Final Wave");
			PlayBossBattle();
		}
	}

	private void PlayBossBattle()
	{
		state = State.InBattle;
		upgradeMenu.SetActive(false);

		// Start boss battle
		Instantiate(bossPrefab);
	}
}

public enum State
{
	InBattle,
	Upgrading,
	Paused,
	Lost,
	Won,
}