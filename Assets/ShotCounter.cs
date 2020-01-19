using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShotCounter : MonoBehaviour
{
    public TextMeshProUGUI shot;

    public static float shotsRemaining = 5f;

    void Start()
    {
        shot.SetText("Shots Remaining: " + shotsRemaining);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shotsRemaining = shotsRemaining-1;
            shot.SetText("Shots Remaining:  " + shotsRemaining);
            if (shotsRemaining == 0)
            {
                shot.SetText("");
            }
        }
    }

}
