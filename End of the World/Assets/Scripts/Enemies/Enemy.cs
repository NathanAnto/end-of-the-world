using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
	protected float hp;
	protected float coinsOnDeath;
	protected float damageToEarth;
	protected abstract void SetHealth();
	protected AudioSource deathAudio;

	[SerializeField] private float speed;
	private GameObject target;
	private Vector2 targetPos;
	private Rigidbody2D rb2D;

	
	void Start()
	{
		target = GameObject.Find("Earth").gameObject;
		targetPos = target.transform.position;
		rb2D = GetComponent<Rigidbody2D>();

		SetHealth();
	}
	
    void Update()
    {
		if (WaveSystem.state == State.InBattle)
		{ 
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

			Earth earth = target.GetComponent<Earth>();

			if (transform.position == target.transform.position)
			{
				Debug.Log(damageToEarth + " Damage dealt to earth");
				earth.DamageEarth(damageToEarth);
				Destroy(gameObject);
			}
		}
		else
		{
			rb2D.velocity = Vector3.zero;
		}
	}

	public void TakeDamage(float damage)
	{
		hp -= damage;

		if (hp <= 0)
		{
			Die();
		}
	}
	
	private void Die()
	{
		deathAudio.Play();
		// Get money
		CoinManager.coins += (int)coinsOnDeath;
		Destroy(gameObject);
	}

}
