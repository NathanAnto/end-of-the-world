using System;
using System.Collections;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
	public float health;
	public float maxHealth = 500f;

	[SerializeField] private GameObject[] enemies;
	[SerializeField] private GameObject asteroid;

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Sprite moon;
	[SerializeField] private Sprite devilMoon;

	private GameObject bossSlider;
	private GameObject target;
	private CircleCollider2D coll;
	private HealthBar bossHealth;
	private IEnumerator vulnerable;
	private IEnumerator ufos;
	private IEnumerator switching;
	private BossStates state;
	private Vector2 screenBounds;
	private Color origionalColor;
	private float speed = 1.5f;
	private float spawnRate = 1.5f;
	private bool canBeDamaged;
	private bool isSpawning;

	// Start is called before the first frame update
	void Start()
	{
		health = maxHealth;
		spriteRenderer.sprite = moon;

		bossSlider = GameObject.Find("Canvas/BossHealthBar");
		bossSlider.transform.GetChild(0).gameObject.SetActive(true);
		bossSlider.transform.GetChild(1).gameObject.SetActive(true);
		bossHealth = bossSlider.GetComponent<HealthBar>();
		bossHealth.SetMaxHealth(maxHealth);
		target = GameObject.Find("Earth").gameObject;
		coll = GetComponent<CircleCollider2D>();
		vulnerable = Vulnerable();
		ufos = SpawningUfo();
		switching = SwitchStates();
		state = BossStates.SpawningUfo;
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		origionalColor = spriteRenderer.color;
		canBeDamaged = true;
		isSpawning = false;

		// Start boss fight
		StartCoroutine(switching);
    }

    // Update is called once per frame
    void Update()
    {
		Move();
		Debug.Log(canBeDamaged);
		if(canBeDamaged)
			coll.enabled = true;
		else
			coll.enabled = false;

		if(health < 100)
		{
			if (!isSpawning)
			{
				spriteRenderer.sprite = devilMoon;
				canBeDamaged = true;
				isSpawning = true;

				// Restart coroutines
				StopCoroutine(vulnerable);
				StopCoroutine(ufos);
				StopCoroutine(switching);
				StartCoroutine(vulnerable);
				StartCoroutine(ufos);
			}
		}
		else
		{
			if (state == BossStates.Vulnerable)
			{
				if (!isSpawning)
				{
					canBeDamaged = true;
					spriteRenderer.sprite = moon;
					isSpawning = true;
					StopCoroutine(ufos);
					StartCoroutine(vulnerable);
				}
			}
			else if (state == BossStates.SpawningUfo)
			{
				if (!isSpawning)
				{
					FlashRed();
					canBeDamaged = false;
					spriteRenderer.sprite = devilMoon;
					isSpawning = true;
					StopCoroutine(vulnerable);
					StartCoroutine(ufos);
				}
			}
		}


		if(health <= 0)
		{
			EndGame();
		}
	}

	private void EndGame()
	{
		throw new NotImplementedException();
	}

	private void FlashRed()
	{
		for (int i = 0; i < 4; i++)
		{
			spriteRenderer.color = Color.red;
			Invoke("ResetColor", .01f);
		}
	}

	private void FlashRedOnce()
	{
		spriteRenderer.color = Color.red;
		Invoke("ResetColor", .1f);
	}

	private void ResetColor()
	{
		spriteRenderer.color = origionalColor;
	}

	public void DamageMoon(float damage)
	{
		FlashRedOnce();
		health -= damage;
		bossHealth.SetHealth(health);
	}

	IEnumerator SwitchStates()
	{
		while (true)
		{
			Debug.Log("Switching !");

			// Make opposite state every 20 seconds
			if (state == BossStates.Vulnerable)
			{
				state = BossStates.SpawningUfo;
				yield return new WaitForSeconds(20f);
			}
			else if(state == BossStates.SpawningUfo)
			{
				state = BossStates.Vulnerable;
				yield return new WaitForSeconds(10f);
			}
			isSpawning = false;
		}
	}

	IEnumerator Vulnerable()
	{
		canBeDamaged = true;
		while (true)
		{
			yield return new WaitForSeconds(spawnRate);

			GameObject newEnemy = Instantiate(asteroid) as GameObject;
			newEnemy.transform.position = new Vector2(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
		}
	}

	IEnumerator SpawningUfo()
	{
		canBeDamaged = false;
		while(true)
		{
			yield return new WaitForSeconds(spawnRate);

			GameObject newEnemy = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)]) as GameObject;
			newEnemy.transform.position = new Vector2(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
		}
	}

	private void Move()
	{
		if (WaveSystem.state == State.InBattle)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

			float dist = Vector2.Distance(target.transform.position, gameObject.transform.position);

			if (dist < 10f)
			{
				target = gameObject;
			}
		}
	}
}

public enum BossStates
{
	Vulnerable,
	SpawningUfo
}