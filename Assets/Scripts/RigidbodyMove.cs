using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
// USAGE: put this on a cube with a rigidbody
// INTENT: let player use WASD/Arrows to move cube around, freeze/unfreeze player movement

// TODO: 
    // figure out how to unfreeze player movement after gameobject is destroyed

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

        myRB.velocity = myInput * 4f;
        
    }

    void OnTriggerStay(Collider other){

        if(other.gameObject.CompareTag("Low Hit") || 
           other.gameObject.CompareTag("Mid Hit") || 
           other.gameObject.CompareTag("High Hit")){

               myRB.isKinematic = true; //player definitely freezes, but they can't move after the object is detroyed? 
               Debug.Log("Monster found"); 
               Debug.Log(other.gameObject.name); 

        }

    }

    public void moveAgain()
    {
        myRB.isKinematic = false;
        Debug.Log("Moved again");  
    }

}
