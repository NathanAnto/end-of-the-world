using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
	public static int coins;

	private Text coinText;

    // Start is called before the first frame update
    void Start()
    {
		coins = 0;
		coinText = GameObject.Find("Canvas/Coins").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		coinText.text = coins + " Coins";
    }
}
