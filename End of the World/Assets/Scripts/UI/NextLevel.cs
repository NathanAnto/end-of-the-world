using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
	public Button btnNextLevel;

	private UpgradeTurret upgradeTurret;
	private TurretShoot turret;
	private CoinManager coinManager;

	void Start()
	{
		turret = GameObject.Find("Turret").gameObject.transform.GetChild(1).GetComponent<TurretShoot>();
		btnNextLevel.GetComponentInChildren<Text>().text = "Next Level \n" + turret.upgradeCost + " Coins";

		upgradeTurret = GameObject.Find("Turret").GetComponent<UpgradeTurret>();
		coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
	}

	public void LevelUpTurret()
	{
		if (coinManager.coins >= turret.upgradeCost)
		{
			upgradeTurret.LevelUp();
			coinManager.coins -= turret.upgradeCost;
		}
	}
}
