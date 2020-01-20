using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingScoreManger : MonoBehaviour
{
    int score = 0;
    public Shotgun gun;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ShotsLeft;

    public void addScore()
    {
        score++;
    }

    private void Update()
    {
        scoreText.SetText("Score: " + score.ToString());
        ShotsLeft.SetText("Shots Left: " + (gun.MaxShots - gun.shots).ToString());
    }

}
