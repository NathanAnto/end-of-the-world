using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private GameObject optionsMenu;

	public void PlayGame()
	{
		AudioManager.instance.Play("Click");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void OpenOptions()
	{
		AudioManager.instance.Play("Click");
		Debug.Log("Options");
		optionsMenu.SetActive(true);
		gameObject.SetActive(false);
	}

	public void QuitGame()
	{
		AudioManager.instance.Play("Click");
		Debug.Log("Quit game");
		Application.Quit();
	}
}
