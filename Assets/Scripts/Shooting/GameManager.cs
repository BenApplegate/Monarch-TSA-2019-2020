using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Launcher skeet1;
    public Launcher skeet2;
    public int power;
    public bool fire1 = false;
    public bool fire2 = false;
    public bool fire3 = false;
    public bool fire4 = false;
    private void Update()
    {
        Debug.Log(Time.time);
            if (Time.timeSinceLevelLoad >= 5 && !fire1)
            {
                skeet2.yeetSkeet(power);
            fire1 = true;
            }
            if (Time.timeSinceLevelLoad >= 10 && !fire2)
            {
                skeet1.yeetSkeet(power);
            fire2 = true;
            }
            if (Time.timeSinceLevelLoad >= 15 && !fire3)
            {
                skeet2.yeetSkeet(power);
            fire3 = true;
            }
            if (Time.timeSinceLevelLoad >= 20 && !fire4)
            {
                skeet1.yeetSkeet(power);
            fire4 = true;
            }
        
    }
    private void Start()
    {
        skeet1.yeetSkeet(power);
        
    }
}
