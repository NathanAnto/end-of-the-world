using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
	protected override void SetHealth()
	{
		deathAudio = GetComponent<AudioSource>();

		hp = Random.Range(10, 21);

		damageToEarth = hp - 5f;
		coinsOnDeath = hp-5;

		float scale = hp;
		transform.localScale = new Vector2(scale, scale);
	}
}
