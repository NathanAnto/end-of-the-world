using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	[SerializeField] private GameObject optionsMenu;
	[SerializeField] private GameObject upgradeMenu;
	private bool isPaused = false;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				ContinueGame();
			}
			else
			{
				PauseGame();
			}
		}
	}
	private void PauseGame()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		Debug.Log("Pause game");
		WaveSystem.state = State.Paused;

		isPaused = true;
		optionsMenu.SetActive(true);
		Time.timeScale = 0;
	}

	public void ContinueGame()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		Debug.Log("Resume game");
		if (upgradeMenu.activeInHierarchy)
		{
			WaveSystem.state = State.Upgrading;
		}
		else
		{
			WaveSystem.state = State.InBattle;
		}

		isPaused = false;
		optionsMenu.SetActive(false);
		Time.timeScale = 1;
	}
}