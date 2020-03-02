using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stroke : MonoBehaviour
{
    public Rigidbody move; // Holds the position of the player for movement
    public Transform pos;
    public float strokeStrength = 0.1f;
    public int air = 100; // Will be consumed through player actions, determines end

    SceneManager SceneManager = new SceneManager();
    float time;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pos.position.x >= 40)
        {
            FindObjectOfType<SwimmingScoreManager>().EndGame();
        }

        Actions();
    }

    private void Actions()
    {
        if (Input.GetKeyDown("a") == true)
        {
            
        }
    }
}
