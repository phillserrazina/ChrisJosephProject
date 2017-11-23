using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// FUNCTIONS

	void Update ()
	{
		// Reload the active scene if "ESC" is pressed.
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
