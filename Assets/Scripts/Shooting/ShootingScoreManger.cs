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

    MainMenuLoader MenuLoader;
    bool Ending = false;

    private void Awake()
    {
        MenuLoader = FindObjectOfType<MainMenuLoader>();
    }
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
            MenuLoader.LoadMenu(1);
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
