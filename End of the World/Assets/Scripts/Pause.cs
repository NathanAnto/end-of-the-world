using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	[SerializeField] private GameObject optionsMenu;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!optionsMenu.activeInHierarchy)
			{
				PauseGame();
			}
			if (optionsMenu.activeInHierarchy)
			{
				ContinueGame();
			}
		}
	}
	private void PauseGame()
	{
		Time.timeScale = 0;
		optionsMenu.SetActive(true);
		//Disable scripts that still work while timescale is set to 0
	}
	private void ContinueGame()
	{
		Time.timeScale = 1;
		optionsMenu.SetActive(false);
		//enable the scripts again
	}
}
