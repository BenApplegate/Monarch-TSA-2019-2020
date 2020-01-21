using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// coxswain changes color to tell what button to press.
public class coxswain : MonoBehaviour
{
    public GameObject cb;
    public GameObject o1;
    public GameObject o2;

    // this is the main script for the game and controls most of the gameplay
    private int ran = 0;
    public bool check;
    public int penalty = 0;
    public int score = 0;
    public bool gets = false;
    Camera MainCamera;
    Renderer m_Renderer;

    void Start()
    {
        // sets it to red to start, may go change to random
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        //This gets the Main Camera from the Scene
        MainCamera = Camera.main;
        //This enables Main Camera
        MainCamera.enabled = true;

        // for checking if thing on screen, copied from unity docs
        m_Renderer = GetComponent<Renderer>();

    }

    void Update()
    {
        
        // create random num
        int r = Random.Range(0, 3);
        ran = r;
        Debug.Log(r);

        // get the color of the boat
        Color32 oj = gameObject.GetComponent<MeshRenderer>().material.color;
        check = testMash(oj);

        // red = space
        // blue = right
        // yellow = left
        // make sure right thing was done
        // want to add so that will move the boat and penaltys for wrong button
        if (check == true)
        {
            r = changeColor();
            // make the boat move
            gameObject.transform.Translate(0, 0, -4);

            // when animation is made call that as well

            // make the camera move when the boat moves
            MainCamera.GetComponent<CameraMove>().GoFaster(-6);
        }
        else
        {
            // make the camera not move
            // stop camera move
            // **** add this ****
        }
        // if the boat goes too far back
        // does not work yet
       /* if (MainCamera.transform.position.x > gameObject.transform.position.x)
        {
            MainCamera.transform.Translate(8, 0, 0);
        }*/

        // also add to score right after
        gets = testMash(oj);
        
        // end the game, incomplete
        if (transform.position.x == 100)
        {
            // need to finish
        }

        

           
    }

    void OnBecameInvisible()
    {
        Camera.main.transform.Translate(-20, 0, 0); 
    }

    // changes the color, uses a random num to do so
    // color refers to what button to press
    int changeColor()
    {
        TestCoroutine();
        if (ran == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            var Renderer1 = cb.GetComponent<Renderer>();
            Renderer1.material.SetColor("_Color", Color.red);
            var Renderer2 = o1.GetComponent<Renderer>();
            Renderer2.material.SetColor("_Color", Color.red);
            var Renderer3 = o2.GetComponent<Renderer>();
            Renderer3.material.SetColor("_Color", Color.red);

            int a = Random.Range(0, 3);
            return a;
        }
        else if (ran == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            var Renderer1 = cb.GetComponent<Renderer>();
            Renderer1.material.SetColor("_Color", Color.blue);
            var Renderer2 = o1.GetComponent<Renderer>();
            Renderer2.material.SetColor("_Color", Color.blue);
            var Renderer3 = o2.GetComponent<Renderer>();
            Renderer3.material.SetColor("_Color", Color.blue);

            int a = Random.Range(0, 3);
            return a;
        }
        else if (ran == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            var Renderer1 = cb.GetComponent<Renderer>();
            Renderer1.material.SetColor("_Color", Color.yellow);
            var Renderer2 = o1.GetComponent<Renderer>();
            Renderer2.material.SetColor("_Color", Color.yellow);
            var Renderer3 = o2.GetComponent<Renderer>();
            Renderer3.material.SetColor("_Color", Color.yellow);

            int a = Random.Range(0, 3);
            return a;
        }
        else
        {
            int a = 0;
            return a;
        }

    }

    // supposed to make code wait...
    IEnumerator TestCoroutine()
    {
            yield return new WaitForSeconds(1);
    }

    // check to see if the boat is ready to change color
    // need to add so that it will move
    bool testMash(Color32 obj)
    {
        Color32 objColor = obj;
        if (Input.GetKeyDown(KeyCode.W) && objColor == Color.red && !BetterPauseMenu.gameIsPaused)
        {
            score = 1;
            check = true;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && objColor == Color.blue && !BetterPauseMenu.gameIsPaused)
        {
            score = 1;
            check = true;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && objColor == Color.yellow && !BetterPauseMenu.gameIsPaused)
        {
            score = 1;
            check = true;
            return true;
        }
        else
        {
            score = 0;
            check = false;
            return false;
        }
        
    }

    public bool getCheck()
    {
        return check;
    }

    public bool getScore()
    {
        return gets;
    }
}

