using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : Enemy
{
	protected override void SetHealth()
	{
		deathAudio = GetComponent<AudioSource>();

		damageToEarth = 10f;
		hp = Random.Range(10, 21);
		coinsOnDeath = Random.Range(5, 11);
	}
}
