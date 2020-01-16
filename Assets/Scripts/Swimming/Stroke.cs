using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stroke : MonoBehaviour
{
    public Transform move; // Holds the position of the player for movement
    public bool apressed; // Signals if "a" key has been pressed
    public bool dpressed; // Signals if "d" key has been pressed

    // Start is called before the first frame update
    void Start()
    {
        apressed = true;
        dpressed = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        if (Input.GetKey(KeyCode.A) == true)
        {
            move.position += new Vector3(3.3f, 0.0f, 0.0f);
            apressed = true;
            dpressed = false;
        }
    } // Checks if A is pressed, and if so, moves the player

    public void CheckD()
    {
        if (Input.GetKey(KeyCode.D)
                == true)
        {
            move.position += new Vector3(3.3f, 0.0f, 0.0f);
            dpressed = true;
            apressed = false;
        }
    } // Checks if D is pressed, and if so, moves the player
}
