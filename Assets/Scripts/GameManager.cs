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
    
    void Start()
    {
        //here is where the menus need to be set to:
        //MainMenu = enabled
        //Pause = disabled
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
        isPaused(); 
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

    public void Restart()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}
