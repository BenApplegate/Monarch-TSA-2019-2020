using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Minigames : MonoBehaviour
{
    // Start is called before the first frame update
    public void archeryGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void shootingGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    public void swimmingGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void weightliftingGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
}
