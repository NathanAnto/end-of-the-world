using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
	public float health;

	[SerializeField] private float duration = 0.15f;
	[SerializeField] private float magnitude = 0.4f;

	private LevelLoader levelLoader;
	private HealthBar healthBar;

	private float maxHealth = 100f;

	private void Start()
	{
		levelLoader = FindObjectOfType<LevelLoader>();
		healthBar = GameObject.Find("Canvas/HealthBar").GetComponent<HealthBar>();
		healthBar.SetMaxHealth(maxHealth);
	}

	public void DamageEarth(float damage)
	{
		StartCoroutine(ShakeScreen(duration, magnitude));
		AudioManager.instance.Play("EarthDamage");
		health -= damage;
		healthBar.SetHealth(health);

		if(health <= 0)
		{
			levelLoader.LoadLost();
			WaveSystem.state = State.Lost;
		}
	}

    public void HealEarth()
	{
		AudioManager.instance.Play("EarthHeal");
		health += 10f;
		healthBar.SetHealth(health);
	}

	public IEnumerator ShakeScreen(float duration, float magnitude)
	{
		Vector3 orignalPosition = Camera.main.transform.position;
		float elapsed = 0f;

		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			Camera.main.transform.position = new Vector3(x, y, -10f);
			elapsed += Time.deltaTime;
			yield return 0;
		}
		Camera.main.transform.position = orignalPosition;
	}
}
