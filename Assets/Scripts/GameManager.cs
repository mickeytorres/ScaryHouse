using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    //intent: store menus and sound fx for the game in here

    public GameObject menuPanel; 

    public RigidbodyMove rigidbodyMove;
    
    void Start()
    {
        //here is where the menus need to be set to:
        //MainMenu = enabled
        //Pause = disabled
        menuPanel.SetActive(true);
        Time.timeScale = 0;  

        
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
        isPaused(); 
        menuUp(); 
    }

    void isPaused()
    {
        if(Input.GetKey(KeyCode.Return)){ //there's a better way to do this, this is just a placeholder for the better version
            Time.timeScale = 0; 
            //enabled PauseScreen
            //escape button to close the pause screen
        }else{
            Time.timeScale = 1; 
        }
    }

    void menuUp(){
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            menuPanel.SetActive(false);
            Time.timeScale = 1;   
        }
    }

    public void Restart() //only restarts on button press
    {
        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
        }
    }

    public void GameOverRestart()
    { //automatically restarts the game when called 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

}
