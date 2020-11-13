using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTurret : MonoBehaviour
{
	public List<GameObject> turrets;
	public GameObject currentTurret;

	private GameObject turret;
	private CoinManager coinManager;

    // Start is called before the first frame update
    void Start()
    {
		currentTurret = turrets[0];
		turret = gameObject.transform.GetChild(1).gameObject;
		coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

	public void LevelUp()
	{
		var upgradeCost = turret.GetComponent<TurretShoot>().upgradeCost;

		coinManager.coins -= upgradeCost;
		// Remove old turret
		turrets.RemoveAt(0);

		// Set currentTurret to the next one
		currentTurret = turrets[0];

		// Destroy old GameObject
		Destroy(turret);

		// Instatiate new one
		Instantiate(currentTurret, new Vector3(0, -4.36f, 0), Quaternion.identity, gameObject.transform);

		turret = gameObject.transform.GetChild(1).gameObject;
	}
}
