using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour {

	// VARIABLES

	private int camCount = 0;

	public bool canMove = true;

	public GameObject waitingCanvas;
	public GameObject playingCanvas;
	public GameObject deadCanvas;
	public GameObject spectateCanvas;

	public Camera[] cams;

	private PlayerSpawn player;

	public Vector3 offset;

	public enum PlayerStates
	{
		WAITING,
		PLAYING,
		DEAD,
		SPECTATING
	}

	public PlayerStates currentState;

	// FUNCTIONS

	void Start()
	{
		currentState = PlayerStates.WAITING;

		player = FindObjectOfType<PlayerSpawn>();
	}

	void Update ()
	{
		cams [1].transform.position = player.playerPrefab [0].transform.position + offset;
		cams [2].transform.position = player.playerPrefab [1].transform.position + offset;
		cams [3].transform.position = player.playerPrefab [2].transform.position + offset;
		cams [4].transform.position = player.playerPrefab [3].transform.position + offset;
		cams [5].transform.position = player.enemyPrefab.transform.position + offset;
		
		switch (currentState) 
		{
		case(PlayerStates.WAITING):

			waitingCanvas.SetActive(true);
			playingCanvas.SetActive(false);
			deadCanvas.SetActive(false);
			spectateCanvas.SetActive(false);

			cams [0].enabled = true;

			cams [1].enabled = false;
			cams [2].enabled = false;
			cams [3].enabled = false;
			cams [4].enabled = false;
			cams [5].enabled = false;

			break;

		case(PlayerStates.PLAYING):

			waitingCanvas.SetActive(false);
			playingCanvas.SetActive(true);
			deadCanvas.SetActive(false);
			spectateCanvas.SetActive(false);

			cams [0].enabled = false;

			cams [1].enabled = true;
			cams [2].enabled = false;
			cams [3].enabled = false;
			cams [4].enabled = false;
			cams [5].enabled = false;

			break;

		case(PlayerStates.DEAD):

			waitingCanvas.SetActive(false);
			playingCanvas.SetActive(false);
			deadCanvas.SetActive(true);
			spectateCanvas.SetActive(false);
			
			break;

		case(PlayerStates.SPECTATING):

			waitingCanvas.SetActive(false);
			playingCanvas.SetActive(false);
			deadCanvas.SetActive(false);
			spectateCanvas.SetActive(true);

			cams [0].enabled = false;

			if(camCount == 1)
			{
				cams [1].enabled = false;
				cams [2].enabled = true;
				cams [3].enabled = false;
				cams [4].enabled = false;
				cams [5].enabled = false;
			}

			else if(camCount == 2)
			{
				cams [1].enabled = false;
				cams [2].enabled = false;
				cams [3].enabled = true;
				cams [4].enabled = false;
				cams [5].enabled = false;
			}

			else if(camCount == 3)
			{
				cams [1].enabled = false;
				cams [2].enabled = false;
				cams [3].enabled = false;
				cams [4].enabled = true;
				cams [5].enabled = false;
			}

			else if(camCount == 4)
			{
				cams [1].enabled = false;
				cams [2].enabled = false;
				cams [3].enabled = false;
				cams [4].enabled = false;
				cams [5].enabled = true;
			}

			break;
		}
	}

	public void NextState()
	{
		currentState = (PlayerStates)(((int)currentState + 1) % 5);
	}

	public void KillPlayer1 ()
	{
		Destroy(GameObject.FindGameObjectWithTag("Player1"));
		NextState();
	}

	public void NextCam ()
	{
		camCount++;

		if (player.twoPlayers == true) 
		{
			camCount = 4;
		} 
		else if (player.threePlayer == true) 
		{
			if (camCount == 2) 
			{
				camCount = 4;
			}
		}
		else if (player.fourPlayer == true) 
		{
			if (camCount == 3) 
			{
				camCount = 4;
			}
		}

		if (camCount >= 5) 
		{
			camCount = 1;
		}
	}

}
