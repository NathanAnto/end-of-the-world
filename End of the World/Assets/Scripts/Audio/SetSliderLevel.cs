using UnityEngine;
using UnityEngine.Audio;

public class SetSliderLevel : MonoBehaviour
{
	public AudioMixer audioMixer;

	public void SetLevel(float sliderValue)
	{
		float newValue = Mathf.Log10(sliderValue) * 20;
		audioMixer.SetFloat("MusicVolume", newValue);
	}
}
