using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
	[SerializeField] private GameObject MainMenu;

	public void OnBack()
	{		
		Debug.Log("Back");
		AudioManager.instance.Play("Click");
		MainMenu.SetActive(true);
		gameObject.SetActive(false);
	}
}
