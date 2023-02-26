using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[SerializeField] private GameObject playerPrefab;
	//This script will hold all the main data for the player:
	private PlayerMovement playerMovmentScript;//will be set when the player is instantiated.
	[SerializeField] private Mythics_PlayerStatsDefualtScriptable playerStats;
	//Setter Function For Player:
	public void InitializePlayer(Transform spawnLocation)
	{
		playerMovmentScript = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation).GetComponentInChildren<PlayerMovement>();//spawn the player and grab the player movement script:
		//Pass in all the data to the Player that was just instantiated:
		playerMovmentScript.InitializePlayer(playerStats.jumpKey_Stats, playerStats.moveSpeed_Stats, playerStats.groundDrag_Stats, playerStats.jumpForce_Stats, playerStats.jumpCoolDown_Stats,
		playerStats.airMultiplier_Stats, playerStats.playerHeight_Stats, playerStats.groundLayer_Stats);
	}
}
