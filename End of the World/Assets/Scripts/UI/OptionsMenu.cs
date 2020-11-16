using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
	[SerializeField] private AudioSource clickAudio;
	[SerializeField] private GameObject optionsMenu;

	public void CloseOptions()
	{
		clickAudio.Play();
		Debug.Log("Back");
		optionsMenu.SetActive(false);
	}
}
