using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpin : MonoBehaviour
{
	private float randSpin;

	private void Start()
	{
		randSpin = Random.Range(-.5f, 0.6f);
	}

	void FixedUpdate()
    {
		transform.Rotate(new Vector3(0, 0, randSpin));
    }
}
