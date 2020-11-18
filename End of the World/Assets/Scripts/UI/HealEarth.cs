using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealEarth : MonoBehaviour
{
	[SerializeField] private Button btnHeal;
	[SerializeField] private AudioSource healAudio;
	[SerializeField] private AudioSource noMoneyAudio;

	private Earth earth;

	private int healCost = 20;

	// Start is called before the first frame update
	void Start()
	{
		earth = GameObject.Find("Earth").GetComponent<Earth>();
	}

    public void Heal()
    {
		if (CoinManager.coins >= healCost)
		{
			if(earth.health < 100)
			{
				CoinManager.coins -= healCost;
				earth.HealEarth();
				healAudio.Play();
				LeanTween.scale(gameObject, new Vector2(1f, 1f), .1f).setLoopPingPong(1);
			}
			else
			{
				CantHeal();
				Debug.Log("Earth already full health");
			}
		}
		else
		{
			CantHeal();
		}
    }

	private void CantHeal()
	{
		noMoneyAudio.Play();
	}
}
