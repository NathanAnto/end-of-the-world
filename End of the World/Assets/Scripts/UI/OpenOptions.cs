using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions : MonoBehaviour
{
	[SerializeField] private GameObject optionsMenu;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("escape"))
		{
			Debug.Log("Pause");
			if(optionsMenu.activeSelf)
			{
				optionsMenu.SetActive(false);
			}
			else
			{
				optionsMenu.SetActive(true);
			}
		}
    }
}
