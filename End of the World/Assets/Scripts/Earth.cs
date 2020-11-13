using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
	public float health;

	[SerializeField] private HealthBar healthBar;

	private float maxHealth = 100f;

	private void Start()
	{
		healthBar = GameObject.Find("Canvas/HealthBar").GetComponent<HealthBar>();
		healthBar.SetMaxHealth(maxHealth);
	}

	public void DamageEarth(float damage)
	{
		health -= damage;
		healthBar.SetHealth(health);
	}

    public void HealEarth()
	{
		health += 10f;
		healthBar.SetHealth(health);
	}
}
