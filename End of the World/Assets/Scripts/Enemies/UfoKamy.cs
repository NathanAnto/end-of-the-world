using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoKamy : Enemy
{
	protected override void SetHealth()
	{
		damageToEarth = 10f;
		hp = 8;
		coinsOnDeath = Random.Range(5, 11);
		target = GameObject.Find("Earth").gameObject;
	}
}
