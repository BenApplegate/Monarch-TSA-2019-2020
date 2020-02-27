using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{

    InputActions input;

    void Awake ()
    {
        input = new InputActions();
    }
    void Start ()
    {
        Time.timeScale = 1f;
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
    }

    void Update ()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

   public void playGame () {
        SceneManager.LoadScene("Archery");
        Time.timeScale = 1f;
   }

   public void QuitGame () 
   {
       Debug.Log("Quit");
       Application.Quit();
   }



}
