using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private AudioSource soundAudio;

	// Initialize the singleton instance.
	private void Start()
	{
		audioMixer = Resources.Load("MasterMixer") as AudioMixer;
		soundAudio.GetComponent<AudioSource>();
	}

	public void PlayAudio()
	{
		Debug.Log("Sound played");
		soundAudio.Play();
	}
}