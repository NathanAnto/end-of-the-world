using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
	public Button btnNextLevel;

	[SerializeField] private AudioSource upgradeCanonAudio;
	[SerializeField] private AudioSource noMoneyAudio;
	private UpgradeTurret upgradeTurret;
	private TurretShoot turret;

	void Start()
	{
		turret = GameObject.Find("Turret").gameObject.transform.GetChild(1).GetComponent<TurretShoot>();
		btnNextLevel.GetComponentInChildren<TextMeshProUGUI>().text = "Next Level \n" + turret.upgradeCost + " Coins";

		upgradeTurret = GameObject.Find("Turret").GetComponent<UpgradeTurret>();
	}

	public void LevelUpTurret()
	{
		if (CoinManager.coins >= turret.upgradeCost)
		{
			upgradeCanonAudio.Play(0);
			CoinManager.coins -= turret.upgradeCost;
			upgradeTurret.LevelUp();
		}
		else
		{
			LeanTween.scale(gameObject, new Vector2(.1f, .1f), .1f).setLoopPingPong(1);
			noMoneyAudio.Play(0);
		}
	}
}
