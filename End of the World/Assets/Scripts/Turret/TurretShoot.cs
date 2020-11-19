using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
	public float damage;
	public int upgradeCost;

	[SerializeField] private float fireRate;
	[SerializeField] private Transform firePoint;
	[SerializeField] private GameObject bullet;

	private float nextFire = 0f;
	private bool canShoot = false;

	// Update is called once per frame
	void Update()
	{
		// Shoot only during a wave
		if (WaveSystem.state == State.InBattle)
		{
			canShoot = Time.time > nextFire;
			// On left mouse click
			if (Input.GetMouseButton(0) && canShoot) // Input.GetButtonDown("Fire1")
			{
				Shoot();
			}
		}
    }

	private void Shoot()
	{
		FindObjectOfType<AudioManager>().Play("TurretShoot");
		nextFire = Time.time + fireRate;
		Instantiate(bullet, firePoint.position, firePoint.rotation);
	}
}
