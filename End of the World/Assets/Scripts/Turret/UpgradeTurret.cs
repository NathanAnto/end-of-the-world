﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTurret : MonoBehaviour
{
	public List<GameObject> turrets;
	public GameObject currentTurret;
	public int upgradeCost;
	public bool isMaxLevel;

	private GameObject turret;

	// Start is called before the first frame update
	void Start()
	{
		currentTurret = turrets[0];
		isMaxLevel = false;
	}

	public void LevelUp()
	{
		// if only one turret in list, don't upgrade
		if(turrets.Count <= 1)
		{
			Debug.Log("Max level");
			isMaxLevel = true;
		}
		else
		{
			turret = gameObject.transform.GetChild(1).gameObject;
			upgradeCost = turret.GetComponent<TurretShoot>().upgradeCost;
			Debug.Log("Upgrade cost: " + upgradeCost);

			CoinManager.coins -= upgradeCost;
			// Remove old turret
			turrets.RemoveAt(0);

			// Set currentTurret to the next one
			currentTurret = turrets[0];

			// Destroy old GameObject
			Destroy(turret);

			// Set new upgrade cost
			upgradeCost = currentTurret.GetComponent<TurretShoot>().upgradeCost;

			// Instatiate new one
			Instantiate(currentTurret, new Vector3(0, -4.36f, 0), Quaternion.identity, gameObject.transform);

			turret = gameObject.transform.GetChild(1).gameObject;
		}
		
	}
}
