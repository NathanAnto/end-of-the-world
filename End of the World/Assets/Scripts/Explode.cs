using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
	private Animator anim;

	// Start is called before the first frame update
	void Start()
    {
		anim = GetComponent<Animator>();
		StartCoroutine(PlayExplosion());		
	}

	IEnumerator PlayExplosion()
	{
		while(true)
		{
			float rand = Random.Range(0.0f, 8.0f);
			yield return new WaitForSeconds(rand);
			anim.SetTrigger("Explode");
		}
	}

	public void resetAnimation()
	{
		anim.SetTrigger("Reset");
	}
}
