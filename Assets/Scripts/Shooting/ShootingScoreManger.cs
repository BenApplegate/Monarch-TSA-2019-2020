using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShootingScoreManger : MonoBehaviour
{
    int score = 0;
    public Shotgun gun;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ShotsLeft;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI NewHighScore;
    public TextMeshProUGUI PressSpace;

    SceneManager SceneManager = new SceneManager();
    bool Ending = false;

    public void addScore()
    {
        score++;
    }

    private void Update()
    {
        scoreText.SetText("Score: " + score.ToString());
        ShotsLeft.SetText("Shots Left: " + (gun.MaxShots - gun.shots).ToString());

        if(Input.GetKey(KeyCode.Space) && Ending)
        {
            SceneManager.LoadScene("BetterMenu");
        }

    }

    public void EndGame()
    {
        ShotsLeft.enabled = false;
        if (!PlayerPrefs.HasKey("ShootingHighScore"))
        {
            PlayerPrefs.SetInt("ShootingHighScore", score);
            NewHighScore.enabled = true;
        }
        else
        {
            if(score > PlayerPrefs.GetInt("ShootingHighScore"))
            {
                PlayerPrefs.SetInt("ShootingHighScore", score);
                NewHighScore.enabled = true;
            }
        }

        HighScore.SetText("High Score: " + PlayerPrefs.GetInt("ShootingHighScore").ToString());
        HighScore.enabled = true;
        PressSpace.enabled = true;
        Ending = true;
    }

}
