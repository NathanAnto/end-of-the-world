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

	protected override void SetHealth()
	{
		damageToEarth = 10f;
		hp = 12;
		coinsOnDeath = Random.Range(5, 11);
		target = GameObject.Find("Earth").gameObject;
		gameObject.GetComponent<ParticleSystem>().Stop();
		earth = GameObject.Find("Earth").GetComponent<Earth>();
	}

	void Update()
	{
		float dist = Vector2.Distance(target.transform.position, gameObject.transform.position);
		Debug.Log("Distance: " + dist);
		Debug.Log("Target: " + target);
		Debug.Log("Speed: " + speed);
		if (dist < 8f)
		{
			StartBeam();
		}
	}

	private void StartBeam()
	{
		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		gameObject.GetComponent<ParticleSystem>().Play();

		canShoot = Time.time > nextFire;

		// On left mouse click
		if (canShoot)
		{
			Debug.Log("BEAM !");
			earth.DamageEarth(2f);
			nextFire = Time.time + fireRate;
		}
	}
}
