using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : Enemy
{
	private Earth earth;
	private bool coroutineStarted = false;

	private float fireRate = 1.5f;
	private float nextFire = 0f;
	private bool canShoot = false;
	private bool beamStarted = false;

	protected override void SetHealth()
	{
		damageToEarth = 10f;
		hp = 12;
		coinsOnDeath = Random.Range(5, 11);
		target = GameObject.Find("Earth").gameObject;
		gameObject.GetComponent<ParticleSystem>().Stop();
		earth = GameObject.Find("Earth").GetComponent<Earth>();
	}

	protected override void Move()
	{
		if(hp <= 0)
		{
			gameObject.GetComponent<ParticleSystem>().Play();
		}

		if (WaveSystem.state == State.InBattle)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

			float dist = Vector2.Distance(target.transform.position, gameObject.transform.position);
			
			if (dist < 8f)
			{
				if(beamStarted)
				{
					ShootEarth();
					target = gameObject;
				}
				else
				{
					nextFire = Time.time + fireRate;
					gameObject.GetComponent<ParticleSystem>().Play();
					beamStarted = true;
				}
			}
		}
	}

	private void ShootEarth()
	{
		canShoot = Time.time > nextFire;

		// On left mouse click
		if (canShoot)
		{
			Debug.Log("Shoot !");
			earth.DamageEarth(2f);
			nextFire = Time.time + fireRate;
		}
	}
}
