using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
	public int coins;

	private Text coinText;

    // Start is called before the first frame update
    void Start()
    {
		coinText = GameObject.Find("Canvas/UpgradeMenu/Coins").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		coinText.text = coins + " Coins";
    }

	public void AddCoins(int amount)
	{
		coins += amount;
	}
}
