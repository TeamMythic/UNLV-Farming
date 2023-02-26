using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFollowScript : MonoBehaviour
{
    [SerializeField] private Transform objectThatsFollowing;
    [SerializeField] private Transform objectToFollow;
    private bool followObject;
    private void Awake()
    {
        followObject = true;
        int amountOfErrors = 0;
        //Error check:
        if(objectThatsFollowing == null)
        {
            amountOfErrors++;
            Debug.Log("You Schmucked up and forgot to put a ref to \"objectThatsFollowing\" in : " + this + " on the object named: " + this.gameObject.name);
        }
		if (objectToFollow == null)
        {
            amountOfErrors++;
            Debug.Log("You Schmucked up and forgot to put a ref to \"objectToFollow\" in : " + this + " on the object named: " + this.gameObject.name);
        }
        if(amountOfErrors > 0)
        {
            Debug.Log($"There was '{amountOfErrors}' error referincing so {this} has deleted itself to not give an error in Update: please stop and fix the error before continuing");
            Destroy(this);
        }
	}
    public void setFollowObject(bool value)
    {//Call this from another script to set weather or not the change the following script.
        //Could be useful to have a player killed and keep the camera at the location for a bit as a ragdoll effect plays or something?
        followObject = value;
    }
    private void Update()
    {//every frame we will move the [object that's following] to the [object to follow]
        if (followObject) objectThatsFollowing.position = objectToFollow.position;
    }
}
