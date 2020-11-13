using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
	public float hp;
	public float coinsOnDeath;

	[SerializeField] private float speed;
	private GameObject target;
	private Vector2 targetPos;

	protected float damageToEarth;
	protected abstract void SetHealth();
	
	void Start()
	{
		target = GameObject.Find("Earth").gameObject;
		targetPos = target.transform.position;

		SetHealth();
	}
	
    void Update()
    {
		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

		Earth earth = target.GetComponent<Earth>();

		if(transform.position == target.transform.position)
		{
			Debug.Log(damageToEarth + " Damage dealt to earth");
			earth.DamageEarth(damageToEarth);
			Destroy(gameObject);
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
		// Get money
		GameObject.Find("CoinManager").GetComponent<CoinManager>().AddCoins((int)coinsOnDeath);
		Destroy(gameObject);
	}

}
