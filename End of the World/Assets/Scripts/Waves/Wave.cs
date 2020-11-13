using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
	public List<GameObject> enemies;
	public bool isWaveDone;
	public int enemyCount;
	public float spawnTime;

	void Start()
	{
		enemyCount = enemies.Count;
		isWaveDone = false;
	}

	void Update()
	{
		enemyCount = enemies.Count;

		if (enemyCount <= 0)
		{
			isWaveDone = true;
		}
	}
}
