using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
	protected float hp;
	protected float coinsOnDeath;
	protected float damageToEarth;
	protected abstract void SetHealth();
	protected abstract void Move();
	protected GameObject target;
	protected Vector2 targetPos;

	[SerializeField] protected float speed;
	private SpriteRenderer spriteRenderer;
	private Animator anim;
	private float flashTime = 0.1f;
	private Color origionalColor;

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
		anim = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		origionalColor = spriteRenderer.color;
	}
	
    void Update()
    {
		Move();
	}

	public void TakeDamage(float damage)
	{
		FlashRed();

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

	private void FlashRed()
	{
		spriteRenderer.color = Color.red;
		Invoke("ResetColor", flashTime);
	}
	private void ResetColor()
	{
		spriteRenderer.color = origionalColor;
	}
}
;

/* 
 public float flashTime;
 Color origionalColor
 public MeshRenderer renderer;
 void Start()
 {
     origionalColor = renderer.color;
 }
 void FlashRed()
 {
     renderer.color = Color.red;
     Invoke("ResetColor", flashTime);
 }
 void ResetColor()
 {
      renderer.color = origionalColor;
 }
*/