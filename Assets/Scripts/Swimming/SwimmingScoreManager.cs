using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SwimmingScoreManager : MonoBehaviour
{
    int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI NewLowScore;
    public TextMeshProUGUI MainMenu;

    bool Ending = false;

    private void Update()
    {
        score = (int)(Time.timeSinceLevelLoad);
        scoreText.SetText("Score: " + score.ToString());

        if(Input.GetKey(KeyCode.Space) && Ending)
        {
            SceneManager SceneManager= new SceneManager();
            SceneManager.LoadScene("BetterMenu");
        }

    }

    public void EndGame()
    {
        Time.timeScale = 0;

        if (!PlayerPrefs.HasKey("SwimmingHighScore"))
        {
            PlayerPrefs.SetInt("SwimmingHighScore", score);
            NewLowScore.enabled = true;
        }
        else if( score < PlayerPrefs.GetInt("SwimmingHighScore"))
        {
            PlayerPrefs.SetInt("SwimmingHighScore", score);
            NewLowScore.enabled = true;
        }
        HighScore.SetText("Lowest Score: " + PlayerPrefs.GetInt("SwimmingHighScore"));
        HighScore.enabled = true;
        MainMenu.enabled = true;
        Ending = true; 
    }
}
