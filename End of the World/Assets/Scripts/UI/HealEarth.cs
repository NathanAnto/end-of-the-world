using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealEarth : MonoBehaviour
{
	[SerializeField] private Button btnHeal;
	private Earth earth;
	private CoinManager coinManager;

	// Start is called before the first frame update
	void Start()
	{
		earth = GameObject.Find("Earth").GetComponent<Earth>();
		coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
	}

    public void Heal()
    {
		if(coinManager.coins >= 20)
		{
			coinManager.coins -= 20;
			earth.HealEarth();
		}
		else
		{
			btnHeal.image.color = Color.red;
		}
    }
}
