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
    //create timer within the triggers to destroy the monsters DONE
    //when timer activated, movement is frozen! figure out why player can't move when object is destroyed?? 
    //Candy Bar isn't working for some reason, look into it.  DONE
    public GameManager gameManager; 
    public Collider _collider; 
    public TextMeshProUGUI braveText; 
    public TextMeshProUGUI timerText;

    int score;

    public float timer; 
    public bool timeIsGoing; 
    public bool isTrigger; 
    


    void Start(){
        braveText.text = "";
        timerText.text = "";
        score = 0;
        timer = 5;

        timeIsGoing = false;
        _collider.isTrigger = true;   
    }   
    void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            braveText.enabled = true; 
            braveText.text = "Ok Ok Ok. Breathe."; 

            //HOW DO I FREEZE PLAYER FROM MOVING WHEN THEY ENTER A TRIGGER 

            timeIsGoing = true;
            if(timeIsGoing){
            SetTimer(); 
            if(timer <= 0f){
                timer = 0f; 
                timerText.enabled = false; 
                timeIsGoing = false; 
                braveText.text = "You ran out of time and Mom is making you move on!\n Press 'R' to try again?"; 

                
                gameManager.GameOverRestart(); //this ends it but it won't restart the game level?  
            }
        }

            if(gameObject.CompareTag("Candy Bar")) //end game object, press enter once to trigger the end! 
            {
                timeIsGoing = false; 
                timerText.text = "";   

                braveText.text = "Trick or treat!\n Press 'Enter' To get your candy & play again!";
                gameManager.Restart(); 
            }

            if(gameObject.CompareTag("Low Hit")) //low hits = 5 spacebar hits
            {
                braveText.text = "I've gotten this far...";
                Debug.Log("Low Hit, 5 presses");
                if(score >= 10)
                {
                    gameObject.SetActive(false); 
                    _collider.isTrigger = false;
                    braveText.text = "Was that supposed to be scary?";
                }

            }

             if(gameObject.CompareTag("Mid Hit")) //mid hits = 8 spacebar hits
            {
                braveText.text = "Mom? Can't we skip this house?";
                Debug.Log("Mid Hit, 8 presses");
                if(score >= 16)
                {
                    gameObject.SetActive(false);
                    _collider.isTrigger = false; 
                    braveText.text = "That wasn't that scary."; 
                }

            }

            if(gameObject.CompareTag("High Hit")) //high hits = 10 spacebar hits
            {
                braveText.text = "Gotta run."; //how the difficulty is displayed
                 Debug.Log("High Hit, 10 presses");
                if(score >= 20)
                {
                    gameObject.SetActive(false);
                    _collider.isTrigger = false;
                    braveText.text = "Okay, go go go go."; 
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

    void SetTimer(){
        timerText.enabled = true; 
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f2"); 
        Debug.Log(timer); 
    }
}
