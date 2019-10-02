using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerJob : MonoBehaviour
{

    //controls what the triggers do
    //trigger jobs: display text & control "hits" 
    //put on the "monster" objects

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
                if(score >= 10)
                {
                    Destroy(gameObject); 
                }

            }

             if(gameObject.CompareTag("Mid Hit")) //mid hits = 8 spacebar hits
            {
                braveText.text = "Mom? Can't we skip this house?";
                if(score >= 16)
                {
                    Destroy(gameObject); 
                }

            }

            if(gameObject.CompareTag("High Hit")) //high hits = 10 spacebar hits
            {
                braveText.text = "Gotta run."; //how the difficulty is displayed
                if(score >= 22)
                {
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
