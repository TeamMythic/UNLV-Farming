//Date: 2/23/22
//COPYRIGHT: YOU ARE ALLOWED TO USE THIS 100% FREE FOR COMMERCIAL AND PERSONAL (just please credit via my YouTube: https://www.youtube.com/channel/UCpbuSisB4iGuvgOrKp5uLcQ).
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MythicsErrorLog;

public class PlayerSpawn : MonoBehaviour
{
    //Namespace Class Objects
        private MythicsErrorLogContainer.MythicsSchmuckLog SchmuckLog = new MythicsErrorLogContainer.MythicsSchmuckLog();//Making a class object to call the functions:
	[Header("Spawn Locations: ")]
    [SerializeField] private List<Transform> spawnLocations = new List<Transform>();
    [Header("Current Location To Spawn Player: ")]
    [SerializeField] private int locationToSpawnPlayer;
    [Header("Player Stats[REFERENCE]: ")]
    [SerializeField] private PlayerStats playerStats;//make sure to reference this in the unity scene:
    private void Start()
    {
        SchmuckLog.Initialize();
		int amountOfErrors = 0;
        if(playerStats == null)
        {
            amountOfErrors++;
            SchmuckLog.SchmuckedUp("playerStats", this);
        }
        if(locationToSpawnPlayer > spawnLocations.Count - 1)
        {
            amountOfErrors++;
            int howFarOff = 0;
            howFarOff = locationToSpawnPlayer - spawnLocations.Count - 1;
            SchmuckLog.ArraySchmuckUp(howFarOff, "SpawnLocations", new Vector2(0, spawnLocations.Count - 1), this);
        }
        if(amountOfErrors == 0)
        {
            playerStats.InitializePlayer(spawnLocations[locationToSpawnPlayer]);
        }
    }
}
