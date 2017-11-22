﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// FUNCTIONS

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
