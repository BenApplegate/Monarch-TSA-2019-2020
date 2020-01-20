using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stroke : MonoBehaviour
{
    public Rigidbody move; // Holds the position of the player for movement
    public Transform pos;
    private bool apressed; // Signals if "a" key has been pressed
    private bool dpressed; // Signals if "d" key has been pressed
    public float strokeStrength = 0.1f;
    SceneManager SceneManager = new SceneManager();
    float time;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        apressed = true;
        dpressed = true;
    }

    private void Update()
    {
        time += Time.timeSinceLevelLoad;
        score = (transform.position.x+49.5f)/(time/100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pos.position.x >= 40)
        {
            SceneManager.LoadScene("BetterMenu");
        }

        if (dpressed == true)
        {
            CheckA();
        }
        else if (apressed == true)
        {
            CheckD();
        }

    }

    public void CheckA()
    {
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            move.AddForce(Vector3.right * strokeStrength);
            apressed = true;
            dpressed = false;
        }
    } // Checks if A is pressed, and if so, moves the player

    public void CheckD()
    {
        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            move.AddForce(Vector3.right * strokeStrength);
            dpressed = true;
            apressed = false;
        }
    } // Checks if D is pressed, and if so, moves the player
}
