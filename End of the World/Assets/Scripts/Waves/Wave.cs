using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
	public List<GameObject> enemies;
	public int enemyCount;
	public float spawnTime;

	void Start()
	{
		enemyCount = enemies.Count;
	}

	void Update()
	{
		enemyCount = enemies.Count;
	}
}
