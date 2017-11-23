using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	// VARIABLES

	public bool twoPlayers = false;			// These variables keep track of
	public bool threePlayer = false;		// how many players are playing.
	public bool fourPlayer = false;
	public bool fivePlayer = false;

	public GameObject[] playerPrefab;		// Stores the player objects.
	public GameObject enemyPrefab;			// Stores the enemy object.

	// FUNCTIONS

	// The following functions instantiate 2-5 players.
	// Positions are based on the prefabs' positions, can easily be altered
	// by changing the prefabs' positions or creating a costum position by
	// creating a Vector3 variable and/or Quaternion if desired.
	// (Make those public or Serializable if you wish to change them in the inspector.)

	public void SpawnTwoPlayers ()
	{
		Instantiate(playerPrefab[0], playerPrefab[0].transform.position, playerPrefab[0].transform.rotation);

		Instantiate(enemyPrefab, enemyPrefab.transform.position, enemyPrefab.transform.rotation);

		twoPlayers = true;
	}

	public void SpawnThreePlayers ()
	{
		Instantiate(playerPrefab[0], playerPrefab[0].transform.position, playerPrefab[0].transform.rotation);
		Instantiate(playerPrefab[1], playerPrefab[1].transform.position, playerPrefab[1].transform.rotation);

		Instantiate(enemyPrefab, enemyPrefab.transform.position, enemyPrefab.transform.rotation);

		threePlayer = true;
	}

	public void SpawnFourPlayers ()
	{
		Instantiate(playerPrefab[0], playerPrefab[0].transform.position, playerPrefab[0].transform.rotation);
		Instantiate(playerPrefab[1], playerPrefab[1].transform.position, playerPrefab[1].transform.rotation);
		Instantiate(playerPrefab[2], playerPrefab[2].transform.position, playerPrefab[2].transform.rotation);

		Instantiate(enemyPrefab, enemyPrefab.transform.position, enemyPrefab.transform.rotation);

		fourPlayer = true;
	}

	public void SpawnFivePlayers ()
	{
		Instantiate(playerPrefab[0], playerPrefab[0].transform.position, playerPrefab[0].transform.rotation);
		Instantiate(playerPrefab[1], playerPrefab[1].transform.position, playerPrefab[1].transform.rotation);
		Instantiate(playerPrefab[2], playerPrefab[2].transform.position, playerPrefab[2].transform.rotation);
		Instantiate(playerPrefab[3], playerPrefab[3].transform.position, playerPrefab[3].transform.rotation);

		Instantiate(enemyPrefab, enemyPrefab.transform.position, enemyPrefab.transform.rotation);

		fivePlayer = true;
	}
}
