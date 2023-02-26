//Date: 2/23/22
//Note this is Dave / GameDevelopment's first person controller, but I expanded upon it greatly:
//new features include scriptable objects, better performance handling, and call features to easily swich data
//and load data. What this means is you can now save a player's data slot on a scriptable object and load it at a later time
//could be useful for saving keybinds, etc. Have fun with my controller. If you end up using this for things other than personal use
//(aka putting on steam or other places to make money )please give credit to...
//ME (Mythic[expanding Dave's FPC]) and Dave (for the initiale FPC iteration [2021])
//COPYRIGHT: YOU ARE ALLOWED TO USE THIS 100% FREE FOR COMMERCIAL AND PERSONAL (just please credit via my YouTube: https://www.youtube.com/channel/UCpbuSisB4iGuvgOrKp5uLcQ).
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Scriptable: ")]
    [SerializeField] private MythicsPlayerMovmentCurrentVariablesScriptable currentData;
    [Header("Orientation: ")]
    [Tooltip("Players Direction: ")]
    [SerializeField] private Transform orientation;
	//Called from the PlayerStats Script to initialize the stats of the player:
	public void InitializePlayer(KeyCode jumpKey, float moveSpeed, float groundDrag, float jumpForce, float jumpCoolDown, 
    float airMultiplier, float playerHeight, LayerMask groundLayer)
    {
		currentData.jump = jumpKey;
		currentData.moveSpeed = moveSpeed;
		currentData.groundDrag = groundDrag;
		currentData.jumpForce = jumpForce;
		currentData.jumpCoolDown = jumpCoolDown;
		currentData.airMultiplier = airMultiplier;
		currentData.playerHeight = playerHeight;
		currentData.groundLayer = groundLayer;
    }
    private void Awake()
    {
        currentData.orientation = orientation;
		currentData.playersRigidbody = GetComponent<Rigidbody>();
		currentData.playersRigidbody.freezeRotation = true;//just so the x,y, and zed are frozen (aka locked) so the capsul will not fall over:
		currentData.canJump = true;
    }
	#region Player Controller Movement Stuff
	    private void Update()
        {
		    HandleInput();//Handle Input:
            HandDrag();//Handle Drag:
            SpeedControl();//Handle Speed:
        }
        private void HandDrag()
        {
		    currentData.grounded = Physics.Raycast(transform.position, Vector3.down, currentData.playerHeight * 0.5f + 0.2f, currentData.groundLayer);
            if(currentData.grounded)//I could just put the above code instead of a bool, but in the future it may be helpful to see if the player is grounded from another script?
            {
			    currentData.playersRigidbody.drag = currentData.groundDrag;
                return;
            }//else
		    currentData.playersRigidbody.drag = 0;
        }
        private void FixedUpdate()//fixed frame rate:
        {/*We are doing this on fixed update because that's when unity calls physics: (according to Unity's documentaiton on MonoBehaviour.FixedUpdate()...
	     Use FixedUpdate when using Rigidbody. Set a force to a Rigidbody and it applies each fixed frame. FixedUpdate occurs at a measured time step
         that typically does not coincide with MonoBehaviour.Update.)*/
		    MovePlayer();
        }
        private void HandleInput()
        {
		    currentData.horizontalInput = Input.GetAxisRaw("Horizontal");
		    currentData.verticalInput = Input.GetAxisRaw("Vertical");
            if(Input.GetKey(currentData.jump) && currentData.canJump && currentData.grounded)//Jump Is A Key Variable Assigned Above
            {
			    currentData.canJump = false;
                Jump();
                Invoke(nameof(ResetJump), currentData.jumpCoolDown);//will call this function after amount of jump cool down has passed:
            }
        }
        private void MovePlayer()
        {
		    currentData.moveDirection = currentData.orientation.forward * currentData.verticalInput + currentData.orientation.right * currentData.horizontalInput;//always walk in direction that we are looking in:
            if (currentData.grounded)
            {
			    currentData.playersRigidbody.AddForce(currentData.moveDirection.normalized * currentData.moveSpeed * 10f, ForceMode.Force);
            }
            else
            {//in air:
			    currentData.playersRigidbody.AddForce(currentData.moveDirection.normalized * currentData.moveSpeed * 10f * currentData.airMultiplier, ForceMode.Force);
		    }
        }
        private void SpeedControl()
        {
            Vector3 flatVelocity = new Vector3(currentData.playersRigidbody.velocity.x, 0f, currentData.playersRigidbody.velocity.z);
            //limit velocity if needed:
            if(flatVelocity.magnitude > currentData.moveSpeed)
            {//Calculate what the speed should be if we are going faster and then apply it:
                Vector3 limitedVelocity = flatVelocity.normalized * currentData.moveSpeed;
			    currentData.playersRigidbody.velocity = new Vector3(limitedVelocity.x, currentData.playersRigidbody.velocity.y, limitedVelocity.z);
            }
        }
        private void Jump()
        {
		    currentData.playersRigidbody.velocity = new Vector3(currentData.playersRigidbody.velocity.x, 0, currentData.playersRigidbody.velocity.z);
		    currentData.playersRigidbody.AddForce(transform.up * currentData.jumpForce, ForceMode.Impulse);
        }
        private void ResetJump()
        {
		    currentData.canJump = true;
        }
	#endregion
	#region Setter Functions
        public void setKeyBind(KeyCode key, string keyName)
        {
            if(keyName.ToLower() == "jump")
            {
			    currentData.jump = key;
            }
        }
        public void setMoveSpeed(float speed)
        {
		    currentData.moveSpeed = speed;
        }
        public void setGroundDrag(float drag)
        {
		    currentData.groundDrag = drag;
        }
        public void setJumpForce(float force)
        {
		    currentData.jumpForce = force;
        }
        public void setJumpCoolDown(float coolDown)
        {
		    currentData.jumpCoolDown = coolDown;
        }
        public void setAirMultiplier(float multi)
        {
		    currentData.airMultiplier = multi;
        }
        public void setPlayerHeight(float height)
        {
		    currentData.playerHeight = height;
        }
        public void setGroundLayer(LayerMask layer)
        {
		    currentData.groundLayer = layer;
        }
	#endregion
    //No need for getter functions here since our stats for the most part is in PlayerStats & called from there is scriptables:
}
