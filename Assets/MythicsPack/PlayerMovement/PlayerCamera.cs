//Date: 2/23/22
//COPYRIGHT: YOU ARE ALLOWED TO USE THIS 100% FREE FOR COMMERCIAL AND PERSONAL (just please credit via my YouTube: https://www.youtube.com/channel/UCpbuSisB4iGuvgOrKp5uLcQ).
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MythicsErrorLog;
public class PlayerCamera : MonoBehaviour
{
    //namespace:
        private MythicsErrorLogContainer.MythicsSchmuckLog schmuckLog = new MythicsErrorLogContainer.MythicsSchmuckLog();
    //These will be changed through a seperate script so if the player object is destroyed we can put the same settings back:
        [SerializeField] private float sensX;
        [SerializeField] private float sensY;
        [SerializeField] private Transform orientation;
        [SerializeField] private Vector2 angleClamp;
    //changed at runtime:
        float xRotation;
        float yRotation;
    private void Awake()
    {
        schmuckLog.Initialize();
		if (0 > sensX)
		{

			schmuckLog.InvalidNumberSchmuckUp(new Vector3(sensX, 0, 400));
		}
		if (0 > sensY)
		{
			schmuckLog.InvalidNumberSchmuckUp(new Vector3(sensY, 0, 400));
		}
		Cursor.lockState = CursorLockMode.Locked;//keep cursor at the center of the screen for first person controller:
        Cursor.visible = false;
    }
    private void Update()
    {
        //Grab input:
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;
	    //Set Rotation:
		    yRotation += mouseX;
            xRotation -= mouseY;
        //Set a clamp so the player cannot look past set points:
            xRotation = Mathf.Clamp(xRotation, angleClamp.x, angleClamp.y);
        //Rotate the camera and orientation:
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);//change rotation along the x and y axis:
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);//change the orientation along the y axis:
    }

}
