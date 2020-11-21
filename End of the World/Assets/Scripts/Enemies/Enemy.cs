using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
	protected float hp;
	protected float coinsOnDeath;
	protected float damageToEarth;
	protected abstract void SetHealth();
	protected GameObject target;

	[SerializeField] protected float speed;
	[SerializeField] private Animator anim;

	protected Vector2 targetPos;
	private bool Death
	{
		get
		{
			return hp <= 0;
		}
	}

	void Start()
	{
		SetHealth();
		targetPos = target.transform.position;
		anim = gameObject.GetComponent<Animator>();
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
	}

	public void TakeDamage(float damage)
	{
		hp -= damage;

		if (Death)
		{
			Die();
		}
	}
	
	private void Die()
	{
		damageToEarth = 0;
		anim.SetTrigger("Death");
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		AudioManager.instance.Play("EnemyExplode");
		// Get money
		CoinManager.coins += (int)coinsOnDeath;
		Destroy(gameObject, .8f);
	}
}
;