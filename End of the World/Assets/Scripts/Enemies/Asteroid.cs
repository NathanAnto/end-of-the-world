using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
	protected override void SetHealth()
	{
		damageToEarth = 5f;
		hp = Random.Range(10, 21);

		coinsOnDeath = hp-5;

		float scale = hp / 10;
		transform.localScale = new Vector2(scale, scale);
	}
}
