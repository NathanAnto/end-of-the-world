using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
	public float health;

	private HealthBar healthBar;

	private float maxHealth = 100f;

	private void Start()
	{
		healthBar = GameObject.Find("Canvas/HealthBar").GetComponent<HealthBar>();
		healthBar.SetMaxHealth(maxHealth);
	}

	public void DamageEarth(float damage)
	{
		AudioManager.instance.Play("EarthDamage");
		health -= damage;
		healthBar.SetHealth(health);
	}

    public void HealEarth()
	{
		AudioManager.instance.Play("EarthHeal");
		health += 10f;
		healthBar.SetHealth(health);
	}
}
