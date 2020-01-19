using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class EndResults : MonoBehaviour
{
    public TextMeshProUGUI Results;
    public TextMeshProUGUI targetsHitEnd;
    public TextMeshProUGUI returnmain;
    public TextMeshProUGUI totalPoints;

    

    // Update is called once per frame
    void Update()
    {
        if(ShotCounter.shotsRemaining == 0f)
        {
            Time.timeScale = 1f;
            Results.SetText("Results");
            targetsHitEnd.SetText("Targets Hit: " + Target.totalHits + "/ 5");
            totalPoints.SetText("Total Points: " + Target.totalpoints);
            returnmain.SetText("Press [Space] to return to the Main Menu");
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("BetterMenu");
            }
        }
    }
}
