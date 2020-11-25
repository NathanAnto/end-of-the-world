using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoKamy : Enemy
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
		damageToEarth = 10f;
		hp = 8;
		coinsOnDeath = Random.Range(5, 11);
		target = GameObject.Find("Earth").gameObject;
	}
}
