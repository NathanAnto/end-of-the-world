using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private AudioSource clickAudio;
	[SerializeField] private GameObject optionsMenu;

	public void PlayGame()
	{
		clickAudio.Play();
		while (clickAudio.isPlaying) { }

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void OpenOptions()
	{
		clickAudio.Play();
		Debug.Log("Options");
		optionsMenu.SetActive(true);
	}

	public void QuitGame()
	{
		clickAudio.Play();
		Debug.Log("Quit game");
		Application.Quit();
	}
}
