using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this script on the main camera !!!
//INTENT: lets player use the mouse to turn the camera like fps game

public class MouseLook : MonoBehaviour
{

    float verticalAngle = 0f; //stores the vertical look in a separate variable so we can avoid eulerangles wrapping around from 180 to -180 etc. 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Cursor.lockState = CursorLockMode.Locked; //locks the cursor to stay in the middle of the screen
        Cursor.visible = false; //hides our ugly lil cursor so we never see it during the game, because it's distracting. 


        float mouseX = Input.GetAxis("Mouse X"); // gets the horitzontal mouse velocity
        float mouseY = Input.GetAxis("Mouse Y"); //vertical velocity, 0 if not moving the mouse

        //this is NOT mouse position

        transform.parent.Rotate(0f, mouseX * 20f, 0f); 

        verticalAngle -= mouseY * 10f; 
        verticalAngle = Mathf.Clamp( verticalAngle, -80f, 80f); //change this range to change how far up/down player can look
        //can do the same to limit how far player can look left/right

        // X = Pitch, Y = Yaw, Z = Roll

        //transform.localEulerAngles.z = 0f; <- can't do this because it's a function disguised as a variable
        transform.localEulerAngles = new Vector3(verticalAngle, 0f, 0f); 

         

        //TODO:
        //non inverted mouselook, flip mouseY ... DONE
        //unroll the camera/freeze z rotation  ... DONE
        //clamp the vertical mouse angle within a range ...DONE 
    }

    void OnTriggerEnter()
    {
        //this is gonna control the UI for the player? 
    }
}
