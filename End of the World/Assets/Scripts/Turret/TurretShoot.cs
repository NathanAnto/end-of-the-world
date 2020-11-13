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

    // Update is called once per frame
    void Update()
    {
		// On left mouse click
        if(Input.GetButtonDown("Fire1") && Time.time >= nextFire)
		{
			Shoot();
		}
    }

	private void Shoot()
	{
		State state = GameObject.Find("Waves").GetComponent<WaveSystem>().state;

		// Shoot only during a wave
		if (state == State.InBattle)
		{
			nextFire = Time.time + 1f / fireRate;
			Instantiate(bullet, firePoint.position, firePoint.rotation);
		}
	}
}
