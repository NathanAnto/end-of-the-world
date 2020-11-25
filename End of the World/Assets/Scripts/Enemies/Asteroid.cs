using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
	protected override void Move()
	{
		if (WaveSystem.state == State.InBattle)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

			Earth earth = target.GetComponent<Earth>();

			if (transform.position == target.transform.position)
			{
				Debug.Log(damageToEarth + " Damage dealt to earth");
				earth.DamageEarth(damageToEarth);
				Destroy(gameObject);
			}
		}
	}

	protected override void SetHealth()
	{
		hp = Random.Range(10, 21);

		damageToEarth = hp - 5f;
		coinsOnDeath = hp - 5;

		float scale = hp;
		transform.localScale = new Vector2(scale, scale);
		target = GameObject.Find("Earth").gameObject;
	}


}
