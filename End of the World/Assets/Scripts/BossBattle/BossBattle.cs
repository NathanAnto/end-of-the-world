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

	private GameObject target;
	private CircleCollider2D collider;
	private float speed = 1.5f;
	private float spawnRate = 3f;
	private bool canBeDamaged;
	private bool isSpawning;
	private BossStates state;
	private Vector2 screenBounds;
	private Color origionalColor;

	// Start is called before the first frame update
	void Start()
	{
		origionalColor = spriteRenderer.color;
		spriteRenderer.sprite = moon;
		target = GameObject.Find("Earth").gameObject;
		collider = GetComponent<CircleCollider2D>();
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		health = maxHealth;
		state = BossStates.SpawningUfo;
		isSpawning = false;
		StartCoroutine(SwitchStates());
    }

    // Update is called once per frame
    void Update()
    {
		if(canBeDamaged)
			collider.enabled = true;
		else
			collider.enabled = false;

		if (state == BossStates.Vulnerable)
		{
			if (!isSpawning)
			{
				Debug.Log("Vulnerable !");
				spriteRenderer.sprite = moon;
				isSpawning = true;
				StopCoroutine(SpawningUfo());
				StartCoroutine(Vulnerable());
			}
			//else isSpawning = false; 			
		}
		else if(state == BossStates.SpawningUfo)
		{
			if (!isSpawning)
			{
				FlashRed();
				Debug.Log("Spawning Ufo's !");
				spriteRenderer.sprite = devilMoon;
				isSpawning = true;
				StopCoroutine(Vulnerable());
				StartCoroutine(SpawningUfo());
			}
			//else isSpawning = false;
		}
	}

	private void FlashRed()
	{
		for (int i = 0; i < 4; i++)
		{
			spriteRenderer.color = Color.red;
			Invoke("ResetColor", .1f);
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
	}

	IEnumerator SwitchStates()
	{
		while (true)
		{
			Debug.Log("Switching !");
			yield return new WaitForSeconds(20f);

			// Make opposite state every 20 seconds
			if (state == BossStates.Vulnerable)
			{
				state = BossStates.SpawningUfo;
				isSpawning = false;
			}
			else
			{
				state = BossStates.Vulnerable;
				isSpawning = false;
			}
		}
	}

	IEnumerator Vulnerable()
	{
		canBeDamaged = true;
		while (true)
		{
			yield return new WaitForSeconds(spawnRate);

			GameObject newEnemy = Instantiate(asteroid) as GameObject;
			Debug.Log("Asteroids");
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