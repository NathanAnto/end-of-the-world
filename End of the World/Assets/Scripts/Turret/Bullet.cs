using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float speed;

	private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.velocity = transform.up * speed;
		Destroy(gameObject, 5f);
    }

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		var enemy = hitInfo.GetComponent<Enemy>();
		var boss = hitInfo.GetComponent<BossBattle>();

		var damage = GameObject.Find("Turret").gameObject.transform.GetChild(1).GetComponent<TurretShoot>().damage;

		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			Destroy(gameObject);
		}
		else if(boss != null)
		{
			boss.DamageMoon(damage);
			Destroy(gameObject);
		}
	}
}
