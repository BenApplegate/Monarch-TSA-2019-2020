using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class HUBLevelLoader : MonoBehaviour
{
    SceneManager SceneManager = new SceneManager();
    public string LevelName;
    public bool CloseGame = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Player")
        {
            if (CloseGame)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(LevelName);
            }
        }
    }
}
