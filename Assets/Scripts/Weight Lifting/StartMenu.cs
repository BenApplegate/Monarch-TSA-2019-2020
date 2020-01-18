using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    
    public static bool GamehasStarted = false;
    public GameObject StartInstructions;

    void Start()
    {
        StartInstructions.SetActive(true);
        Time.timeScale = 0;
        GamehasStarted = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!(GamehasStarted))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
        else 
        {
            return;
        }
    }

    void StartGame()
    {
        Time.timeScale = 1;
        StartInstructions.SetActive(false);
        GamehasStarted = true;
    }

    void StartMenuAppear()
    {
            StartInstructions.SetActive(true);
            Time.timeScale = 0;
            GamehasStarted = false;
    }
}
