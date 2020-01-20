using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{ 

    public coxswain chec;

    bool score = false;
    public int numscore = 0;
    public float ctime = 30f;
    //float stime = 30f;

    public Text stext;
    public Text TimerText;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI NewHighScore;
    public TextMeshProUGUI Space;

    bool Ending = false;
    SceneManager SceneManager = new SceneManager();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ctime -= 1 * Time.deltaTime;
        

        if (ctime <= 0)
        {
            EndGame();
        }
        

        // calulate score, works meh
        if (Input.anyKey)
        {
            score = chec.getScore();
            if (score == true)
                numscore += 1;
            // should have no negative socres
            if (numscore < 0)
                numscore = 0;

            // display the score
            stext.text = "Score: " + numscore;
        }

        if(Input.GetKey(KeyCode.Space) && Ending)
        {
            SceneManager.LoadScene("BetterMenu");
        }
        
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        stext.enabled = false;
        TimerText.enabled = false;
        chec.enabled = false;
        scoreText.SetText("Score: " + numscore.ToString());
        scoreText.enabled = true;

        if (!PlayerPrefs.HasKey("RowingHighScore"))
        {
            PlayerPrefs.SetInt("RowingHighScore", numscore);
            NewHighScore.enabled = true;
        }
        else
        {
             if(numscore > PlayerPrefs.GetInt("RowingHighScore"))
            {
                PlayerPrefs.SetInt("RowingHighScore", numscore);
                NewHighScore.enabled = true;
            }
        }

        HighScore.SetText("High Score: " + PlayerPrefs.GetInt("RowingHighScore"));
        HighScore.enabled = true;
        Space.enabled = true;

        Ending = true;
    }

    // return the score
    public int getScore()
    {
        return numscore;
    }
    
    
    

    
}
