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
	private string btnText;

	void Start()
	{
		turret = GameObject.Find("Turret").gameObject.transform.GetChild(1).GetComponent<TurretShoot>();
		btnNextLevel.GetComponentInChildren<TextMeshProUGUI>().text = "Next Level \n" + turret.upgradeCost + " Coins";

		upgradeTurret = GameObject.Find("Turret").GetComponent<UpgradeTurret>();
	}

	public void LevelUpTurret()
	{
		turret = GameObject.Find("Turret").gameObject.transform.GetChild(1).GetComponent<TurretShoot>();
		if (CoinManager.coins >= turret.upgradeCost)
		{
			LeanTween.scale(gameObject, new Vector2(.1f, .1f), .1f).setLoopPingPong(1);
			FindObjectOfType<AudioManager>().Play("UpgradeCannon");
			upgradeTurret.LevelUp();
			btnNextLevel.GetComponentInChildren<TextMeshProUGUI>().text = "Next Level \n" + upgradeTurret.upgradeCost + " Coins";
		}
		else
		{
			FindObjectOfType<AudioManager>().Play("Nope");
		}
	}
}
