using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] private Animator transition;
	[SerializeField] private int transitionTime;
	[SerializeField] private AudioMixer audioMixer;

	void Start()
	{
		audioMixer.SetFloat("MusicVolume", Mathf.Log10(.5f) * 20);
	}

	public void PlayFade()
	{
		StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1));
	}

	public void RestartGame()
	{
		AudioManager.instance.Play("Click");
		// Load Game Scene
		StartCoroutine(LoadNextScene(2));
	}

	public void LoadLost()
	{
		// Load Game Scene
		StartCoroutine(LoadNextScene(3));
	}

	private IEnumerator LoadNextScene(int nextScene)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(nextScene);
	}
}
