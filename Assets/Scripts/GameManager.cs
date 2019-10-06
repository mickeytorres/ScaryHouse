using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
        isPaused(); 
    }

    void isPaused()
    {
        if(Input.GetKey(KeyCode.Return)){
            Time.timeScale = 0; 
        }else{
            Time.timeScale = 1; 
        }
    }

    void Restart()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}
