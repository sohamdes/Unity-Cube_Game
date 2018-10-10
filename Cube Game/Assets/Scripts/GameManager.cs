﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {

    public static int currentScore;
    public static int highScore;

    public static int currentLevel =0;
    public static int unlockedLevel;

    // Use this for initialization
    public static void CompleteLevel() {

        if(currentLevel < 2){
            currentLevel += 1;
            SceneManager.LoadScene(currentLevel);
        }
        else{
            print("You Win!");
        }
    }
}
