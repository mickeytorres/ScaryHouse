using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodySpaceship : MonoBehaviour
{

    //USAGE: on a cube with rigidbody, gravity is off
    //INTENT: let us control cube like a spaceship
    public Rigidbody myRB; 
    Vector3 inputVector; 

    // Update is called once per frame
    void Update()
    {
        //TODO LIST:
        // - grab input (getaxis?)
        // - put the input into a vector
        // - use that vector in fixedupdate to do physics stuff 

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 
        bool thrust = Input.GetKey(KeyCode.Space); 

        inputVector.y = horizontal; //horizontal turning
        inputVector.x = vertical;  //vertical turning 
        
        if( thrust ) {
            inputVector.z = 1f;
        } else {
            inputVector.z = 0f; 
        }
    }

    void FixedUpdate()
    {
        //rotational force is called torque

        myRB.AddRelativeTorque(inputVector.x, inputVector.y, 0f); 
        myRB.AddRelativeForce(0f, 0f, inputVector.z * 5f); 
    }
}
