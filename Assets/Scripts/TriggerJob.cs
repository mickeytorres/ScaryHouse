using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerJob : MonoBehaviour
{

    //controls what the triggers do
    //trigger jobs: display text & control "hits" 
    //put on the "monster" objects

    //this holds, timers, text, and enabled/disabled gameObjects. 

    //TODO: 
    //create timer within the triggers to destroy the monsters
    //make player stay put so they cna't just run away (might be solved in level design instead)

    [SerializeField] private TextMeshProUGUI braveText; 

    int score;


    void Start(){
        braveText.text = "";
        score = 0;
    }   
    void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            braveText.enabled = true; 
            braveText.text = "Ok Ok Ok. Breathe."; 

            if(gameObject.CompareTag("Low Hit")) //low hits = 5 spacebar hits
            {
                braveText.text = "I've gotten this far...";
                Debug.Log("Low Hit, 5 presses");
                if(score >= 10)
                {
                    Destroy(gameObject); 
                    braveText.text = "Was that supposed to be scary?";
                }

            }

             if(gameObject.CompareTag("Mid Hit")) //mid hits = 8 spacebar hits
            {
                braveText.text = "Mom? Can't we skip this house?";
                Debug.Log("Mid Hit, 8 presses");
                if(score >= 16)
                {
                    Destroy(gameObject);
                    braveText.text = "That wasn't that scary."; 
                }

            }

            if(gameObject.CompareTag("High Hit")) //high hits = 10 spacebar hits
            {
                braveText.text = "Gotta run."; //how the difficulty is displayed
                 Debug.Log("High Hit, 10 presses");
                if(score >= 20)
                {
                    Destroy(gameObject);
                    braveText.text = "Okay, go go go go."; 
                }

            }

            if(gameObject.CompareTag("Candy Bar"))
            {
                braveText.text = "Woah! King size?!";

                if(Input.GetKey(KeyCode.Space)){
                    braveText.text = "I'm never coming here again, though.";
                    Destroy(gameObject); 
                }
            }

            addPoint();
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            braveText.enabled = false; 
        }
    }

    void addPoint(){
        if(Input.GetKeyDown(KeyCode.Space)){
            score++; //score increases by 2; 
        }
        Debug.Log("Score: " + score); //displays the score in console for us to check how this works out? 
    }
}
