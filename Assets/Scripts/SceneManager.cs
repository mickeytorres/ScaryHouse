﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class SceneSort : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadGame(){
        SceneManager.LoadScene(0);  
    }

    public void OptionsScreen(){
        //SceneManager.LoadScene(0); 
    }
}
