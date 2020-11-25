using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour
{
	[SerializeField] private LevelLoader levelLoader;

	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			levelLoader.PlayFade();
		}
    }
}
