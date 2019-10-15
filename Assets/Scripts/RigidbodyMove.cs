using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
//USAGE: put this on a cube with a rigidbody
// INTENT: let player use WASD/Arrows to move cube around
    Rigidbody myRB; 
    Vector3 myInput;

    //public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>(); 

    }

    // Update is called once per frame, used for input and graphics
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // a/d or left/right
        float vertical = Input.GetAxis("Vertical"); // w/s or up/down

        // transform.Translate() does NOT account for physics/collision! BAD

        myInput = horizontal * transform.right;
        myInput += vertical * transform.forward;

    }

    //fixedUpdate is like Update, but for physics, funs at a different update speed. 
    void FixedUpdate()
    {
        // myRB.AddForce(myInput * 100f); good for spaceships/cars/boats, etc, they don't start up and slide around.  (addForce)

        myRB.velocity = myInput * 4f;
        
        // if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightCommand)){
        //     myRB.velocity = myInput * 30f; //increases the speed overall when player holds down shift
        //     //this isn't working, so what's a better way to do it? 
        // }
    }

    void OnTriggerStay(Collider other){

        if(other.gameObject.CompareTag("Low Hit") || 
           other.gameObject.CompareTag("Mid Hit") || 
           other.gameObject.CompareTag("High Hit")){

               myRB.constraints = RigidbodyConstraints.FreezePosition; 
               Debug.Log("Monster found"); 

        }

    }

    void OnTriggerExit (Collider other){

        myRB.constraints = RigidbodyConstraints.None; 

    }
}
