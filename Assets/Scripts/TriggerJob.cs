using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerJob : MonoBehaviour
{
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
            if(score == 10)
            {
                braveText.text = "I've gotten this far...";
            }else if(score == 20){
                braveText.text = "So close.";
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
            score = score + 1; //score increases by 1; 
        }
        Debug.Log("Score: " + score); //displays the score in console for us to check how this works out? 
    }
}
