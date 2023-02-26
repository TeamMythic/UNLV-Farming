//Date: 2/23/22
//COPYRIGHT: YOU ARE ALLOWED TO USE THIS 100% FREE FOR COMMERCIAL AND PERSONAL (just please credit [at Mythic {email: mythicgaming234@gmail.com}]).
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "Do Not Change Values: (Please Rename)", menuName = "current player Movement Data")]
//Please make sure there is only 1 of these and they are hooked up to the player. This will be the data that is changed.
public class MythicsPlayerMovmentCurrentVariablesScriptable : ScriptableObject
{//The reason these are all hidden is because no data needs to be initalized (they are set upon the player being instantiated by the player stats script).
	//KeyBinds:
		[HideInInspector] public KeyCode jump = KeyCode.Space;//space by defualt:
	//Movement:
		[HideInInspector] public Transform orientation;
		[HideInInspector] public float moveSpeed;
		[HideInInspector] public float groundDrag;//without this the player will not have drag and will feel like it is on ice:
		[HideInInspector] public float jumpForce;
		[HideInInspector] public float jumpCoolDown;
		[HideInInspector] public float airMultiplier;
	//Calculated Movement Values:
		[HideInInspector] public bool canJump;
		[HideInInspector] public float horizontalInput;
		[HideInInspector] public float verticalInput;
	//GroundCheck:
		[HideInInspector] public float playerHeight;
		[HideInInspector] public LayerMask groundLayer;//Make sure that you add any layers you wish to do ground check and add drag :)
		[HideInInspector] public bool grounded;
	//Direction:
		[HideInInspector] public Vector3 moveDirection;
	//Other:
		[HideInInspector] public Rigidbody playersRigidbody;

}
