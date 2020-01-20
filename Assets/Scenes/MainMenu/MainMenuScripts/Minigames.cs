using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Minigames : MonoBehaviour
{
    
    public TextMeshProUGUI archeryHighScore;
    public TextMeshProUGUI shootingHighScore;
    
    private void Start(){
        if(PlayerPrefs.HasKey("ArcheryHighScore")){
        archeryHighScore.SetText("High Score: " + PlayerPrefs.GetInt("ArcheryHighScore"));
        }
        else{
            archeryHighScore.SetText("High Score: 0");
        }

        if (PlayerPrefs.HasKey("ShootingHighScore"))
        {
            shootingHighScore.SetText("High Score: " + PlayerPrefs.GetInt("ShootingHighScore"));
        }
        else
        {
            shootingHighScore.SetText("High Score: 0");
        }
    }

    public void archeryGame () {
        SceneManager.LoadScene("Archery");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void shootingGame () {
        SceneManager.LoadScene("Shooting");
    }
    
    public void swimmingGame () {
        SceneManager.LoadScene("Swimming");
    }

    public void rowingGame () {
        SceneManager.LoadScene("RowingGameNew");
    }
}
