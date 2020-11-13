using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
	[SerializeField] private AudioSource clickAudio;
	private WaveSystem wave;

    // Start is called before the first frame update
    void Start()
    {
		wave = GameObject.Find("Waves").GetComponent<WaveSystem>();
    }

    public void StartNextWave()
	{
		clickAudio.Play(0);
		wave.StartNextWave();
	}
}
