﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
	public float degreesPerSecond = 15.0f;
	public float amplitude = 0.5f;
	public float frequency = 1f;

	private Vector3 posOffset;
	private Vector3 tempPos;

	// Start is called before the first frame update
	void Start()
	{
		// Store the starting position & rotation of the object
		posOffset = transform.position;
	}

    // Update is called once per frame
    void Update()
	{
		// Float up/down with a Sin()
		tempPos = posOffset;
		tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

		transform.position = tempPos;
	}
}
