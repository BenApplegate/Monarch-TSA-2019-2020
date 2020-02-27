using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArcheryScoreManager : MonoBehaviour
{
    int score = 0;
    public Text scoreText;
    public Image CrossHair;
    public Text HighScore;
    public Text NewHighScore;
    public Text MainMenu;
    public Text ArrowsLeft;
    MainMenuLoader MainMenuLoader;


    private void Awake()
    {
        MainMenuLoader = FindObjectOfType<MainMenuLoader>();    
    }

    public void AddScore(Collider item)
    {
        if (item.name == "Center")
        {
            score += 10;
        }
        else if (item.name == "Small")
        {
            score += 7;
        }
        else if (item.name == "Medium")
        {
            score += 4;
        }
        else if (item.name == "Large")
        {
            score += 1;
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();

        if (MainMenu.enabled)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                MainMenuLoader.LoadMenu(0);
            }
        }
    }

    public void EndGame()
    {
        ArrowsLeft.enabled = false;
        MainMenu.enabled = true;
        CrossHair.enabled = false;
        if (!PlayerPrefs.HasKey("ArcheryHighScore"))
        {
            PlayerPrefs.SetInt("ArcheryHighScore", score);
        }
        else
        {
            if(score > PlayerPrefs.GetInt("ArcheryHighScore"))
            {
                PlayerPrefs.SetInt("ArcheryHighScore", score);
                NewHighScore.enabled = true;
            }
        }
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("ArcheryHighScore").ToString();
        HighScore.enabled = true;
    }

}
