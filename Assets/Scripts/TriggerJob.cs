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
    //when timer activated, movement is frozen! figure out why player can't move when object is destroyed?? 

    public GameManager gameManager; 

   public  RigidbodyMove rigidbodyMove; 

    public GameObject player;
    public GameObject endMenu;  

    public Collider _collider; 
    public TextMeshProUGUI braveText; 
    public TextMeshProUGUI timerText;

    int score;

    public float timer; 
    public float x = 0.1f;
    public float y = 0.1f; 
    public float z = 0.1f; 
    public bool timeIsGoing; 
    public bool isTrigger; 
    public bool seenMonster; 
    


    void Start(){
        braveText.text = "";
        timerText.text = "";
        score = 0;
        timer = 5;
        endMenu.SetActive(false); 

        player = GameObject.Find("player"); 
      //rigidbodyMove = player.GetComponent<RigidbodyMove>(); 

        timeIsGoing = false;
        _collider.isTrigger = true; 
        seenMonster = false;   
    }  

    void Update(){
        if(seenMonster)
        {
            if(gameObject.CompareTag("Candy Bar")) //end game object, press enter once to trigger the end! 
            {
                timeIsGoing = false; 
                timerText.text = "";   

                braveText.text = "Trick or treat!\n Press 'Enter' To get your candy & play again!";
                endGame();  
            }

            if(gameObject.CompareTag("Low Hit")) //low hits = 5 spacebar hits
            {
                braveText.text = "I've gotten this far...";
                Debug.Log("Low Hit, 5 presses");
                if(score >= 5)
                {
                    gameObject.SetActive(false);
                    rigidbodyMove.moveAgain(); 
                    _collider.isTrigger = false;
                    braveText.text = "Was that supposed to be scary?";
                }

            }

             if(gameObject.CompareTag("Mid Hit")) //mid hits = 8 spacebar hits
            {
                braveText.text = "Mom? Can't we skip this house?";
                //seenMonster = true;
                Debug.Log("Mid Hit, 8 presses");
                if(score >= 10)
                {
                    gameObject.SetActive(false);
                    rigidbodyMove.moveAgain(); 
                    _collider.isTrigger = false; 
                    braveText.text = "That wasn't that scary."; 
                }

            }

            if(gameObject.CompareTag("High Hit")) //high hits = 10 spacebar hits
            {
                braveText.text = "Gotta run."; //how the difficulty is displayed
               // seenMonster = true;
                 Debug.Log("High Hit, 10 presses");
                if(score >= 15)
                {
                    gameObject.SetActive(false);
                    rigidbodyMove.moveAgain(); 
                    _collider.isTrigger = false;
                    braveText.text = "Okay, go go go go."; 
                }

            }

            addPoint();
        }

        if(timeIsGoing)
        {
                SetTimer(); 
                if(timer <= 0f){
                    timer = 0f; 
                    timerText.enabled = false; 
                    timeIsGoing = false; 
                    gameManager.GameOverRestart(); 
                }
        }
    } 

    void SetTimer(){
        timerText.enabled = true; 
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f2"); 
        Debug.Log(timer); 
    }

     void addPoint(){
        
            if(Input.GetKeyDown(KeyCode.Space))
            {
                score++; //score increases by 2;
                transform.localScale -= new Vector3 (x, y, z);  
            }
        
        
        Debug.Log("Score: " + score); //displays the score in console for us to check how this works out? 
    }
    void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                braveText.enabled = true; 
                braveText.text = "Ok Ok Ok. Breathe.";
                timeIsGoing = true;
                seenMonster = true;
            }    
        }

    void endGame(){
        endMenu.SetActive(true); 
        gameManager.Restart(); 
    }
}
