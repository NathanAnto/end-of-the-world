using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	[SerializeField]
	private GameObject[] enemies;

	private Vector2 screenBounds;
	private float spawnTime = 1f;

	// Start is called before the first frame update
	void Start()
    {
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine(EnemySpawning());
	}

	private void SpawnEnemy()
	{
		var enemy = enemies[Random.Range(0, enemies.Length)];

		GameObject a = Instantiate(enemy) as GameObject;
		a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
	}

	IEnumerator EnemySpawning()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnTime);
			SpawnEnemy();
		}
	}
}
