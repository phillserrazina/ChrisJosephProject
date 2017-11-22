using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	// VARIABLES

	public bool twoPlayers = false;
	public bool threePlayer = false;
	public bool fourPlayer = false;
	public bool fivePlayer = false;

	public GameObject[] playerPrefab;
	public GameObject enemyPrefab;

	// FUNCTIONS

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
