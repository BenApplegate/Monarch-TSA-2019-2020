using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcheryScoreManager : MonoBehaviour
{
    int score = 0;
    public Text scoreText;

    public void AddScore(Collider item)
    {
        if(item.name == "Center")
        {
            score += 10;
        }
        else if(item.name == "Small")
        {
            score += 7;
        }
        else if(item.name == "Medium")
        {
            score += 4;
        }
        else if(item.name == "Large")
        {
            score += 1;
        }
        Debug.Log(score);
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
