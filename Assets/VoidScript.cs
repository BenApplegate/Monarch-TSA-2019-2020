using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class VoidScript : MonoBehaviour
{
    SceneManager SceneManager = new SceneManager();
    public string LevelName;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}
