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
	[SerializeField] private AudioSource shootAudio;

	private float nextFire = 0f;

	// Update is called once per frame
	void Update()
	{
		// Shoot only during a wave
		if (WaveSystem.state == State.InBattle)
		{
			// On left mouse click
			if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
			{
				Shoot();
			}
		}
    }

	private void Shoot()
	{
		shootAudio.Play();
		nextFire = Time.time + fireRate;
		Instantiate(bullet, firePoint.position, firePoint.rotation);
	}
}
