using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
	public string name;

	public AudioClip clip;
	public AudioMixerGroup audioMixer;

	[Range(0.001f, 1)]
	public float volume;
	[Range(.1f, 3f)]
	public float pitch;

	public bool loop;

	[HideInInspector]
	public AudioSource source;
}
