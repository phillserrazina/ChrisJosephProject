using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour {

	// VARIABLES

	private int camCount = 0;			// Keeps track of what camera is being used.

	public GameObject waitingCanvas;	// Canvas used when in WAITING phase.
	public GameObject playingCanvas;	// Canvas used when in PLAYING phase.
	public GameObject deadCanvas;		// Canvas used when in DEAD phase.
	public GameObject spectateCanvas;	// Canvas used when in SPECTATING phase.

	public Camera[] cams;				// Array that contains all the cameras that will be used.

	private PlayerSpawn player;			// Access to the PlayerSpawn script.

	public Vector3 offset;				// Used to change the camera's position from the player's position.

	public enum PlayerStates
	{
		WAITING,
		PLAYING,
		DEAD,
		SPECTATING
	}

	public PlayerStates currentState;	// Keeps track of the game state.

	// FUNCTIONS

	void Start()
	{
		currentState = PlayerStates.WAITING;

		player = FindObjectOfType<PlayerSpawn>();
	}

	void Update ()
	{
		// Here we assign each camera to the respective player, putting them in the same position
		// of their assigned player.
		cams [1].transform.position = player.playerPrefab [0].transform.position + offset;
		cams [2].transform.position = player.playerPrefab [1].transform.position + offset;
		cams [3].transform.position = player.playerPrefab [2].transform.position + offset;
		cams [4].transform.position = player.playerPrefab [3].transform.position + offset;
		cams [5].transform.position = player.enemyPrefab.transform.position + offset;


		// State switch
		switch (currentState) 
		{
		case(PlayerStates.WAITING):					// ======== WAITING STATE ========

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

		case(PlayerStates.PLAYING):					// ======== PLAYING STATE ========

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

		case(PlayerStates.DEAD):					// ======== DEAD STATE ========

			waitingCanvas.SetActive(false);
			playingCanvas.SetActive(false);
			deadCanvas.SetActive(true);
			spectateCanvas.SetActive(false);
			
			break;

		case(PlayerStates.SPECTATING):				// ======== SPECTATING STATE ========

			waitingCanvas.SetActive(false);
			playingCanvas.SetActive(false);
			deadCanvas.SetActive(false);
			spectateCanvas.SetActive(true);

			cams [0].enabled = false;

			// Changes the active camera based on the camCount.
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


	// "NextState" function, changes the currentState to the next state 
	// in the enum list.
	public void NextState()
	{
		currentState = (PlayerStates)(((int)currentState + 1) % 5);
	}


	// Kills P1 and moves on to the next state (DEAD state).
	public void KillPlayer1 ()
	{
		Destroy(GameObject.FindGameObjectWithTag("Player1"));
		NextState();
	}


	// Changes the current camera to the next camera in the "cams" array
	// by increasing the camCount variable. Also sets restrictions based
	// on how many players are playing.
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
