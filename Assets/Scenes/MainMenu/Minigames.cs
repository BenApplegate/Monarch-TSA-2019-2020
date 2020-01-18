﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Minigames : MonoBehaviour
{
    
    public TextMeshProUGUI archeryHighScore;
    
    private void Start(){
        if(PlayerPrefs.HasKey("ArcheryHighScore")){
        archeryHighScore.SetText("High Score: " + PlayerPrefs.GetInt("ArcheryHighScore"));
        }
        else{
            archeryHighScore.SetText("High Score: 0");
        }
    }

    public void archeryGame () {
        SceneManager.LoadScene("Archery");
    }

    public void shootingGame () {
        SceneManager.LoadScene("Shooting");
    }
    
    public void swimmingGame () {
        SceneManager.LoadScene("Swimming");
    }

    public void weightliftingGame () {
        SceneManager.LoadScene("Weight Lifting");
    }

    public void rowingGame () {
        SceneManager.LoadScene("Rowing");
    }
}
