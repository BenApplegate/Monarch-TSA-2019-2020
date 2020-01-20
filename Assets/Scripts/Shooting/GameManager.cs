using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Launcher skeet1;
    public Launcher skeet2;
    public Launcher skeet3;
    public int power;
    public bool fire1 = false;
    public bool fire2 = false;
    public bool fire3 = false;
    public bool fire4 = false;
    public bool fire5 = false;
    public bool fire6 = false;
    public bool fire7 = false;
    public bool fire8 = false;
    public bool fire9 = false;
    public bool fire10 = false;
    public bool fire11 = false;
    public bool fire12 = false;
    public bool fire13 = false;
    public bool fire14 = false;
    public bool fire15 = false;

    public TextMeshProUGUI SkeetsLeft;
    public Shotgun gun;
    BetterPauseMenu BetterPauseMenu;
    public ShootingScoreManger scoreManger;

    private void Start()
    {
        BetterPauseMenu = FindObjectOfType<BetterPauseMenu>();
        SkeetsLeft.SetText("Skeets Left: 15");
    }

    private void Update()
    {

            if (Time.timeSinceLevelLoad >= 5 && !fire1)
            {
                skeet1.yeetSkeet(power);
            fire1 = true;
            SkeetsLeft.SetText("Skeets Left: 14");
        }
            if (Time.timeSinceLevelLoad >= 10 && !fire2)
            {
                skeet2.yeetSkeet(power);
            fire2 = true;
            SkeetsLeft.SetText("Skeets Left: 13");
        }
            if (Time.timeSinceLevelLoad >= 15 && !fire3)
            {
                skeet3.yeetSkeet(power);
            fire3 = true;
            SkeetsLeft.SetText("Skeets Left: 12");
        }
            if (Time.timeSinceLevelLoad >= 20 && !fire4)
            {
                skeet1.yeetSkeet(power);
            fire4 = true;
            SkeetsLeft.SetText("Skeets Left: 11");
        }
            if (Time.timeSinceLevelLoad >= 25 && !fire5)
            {
                skeet2.yeetSkeet(power);
                fire5 = true;
            SkeetsLeft.SetText("Skeets Left: 10");
        }
            if (Time.timeSinceLevelLoad >= 30 && !fire6)
            {
                skeet3.yeetSkeet(power);
                fire6 = true;
            SkeetsLeft.SetText("Skeets Left: 9");
        }
        if (Time.timeSinceLevelLoad >= 35 && !fire7)
        {
            skeet1.yeetSkeet(power);
            fire7 = true;
            SkeetsLeft.SetText("Skeets Left: 8");
        }
        if (Time.timeSinceLevelLoad >= 40 && !fire8)
        {
            skeet2.yeetSkeet(power);
            fire8 = true;
            SkeetsLeft.SetText("Skeets Left: 7");
        }
        if (Time.timeSinceLevelLoad >= 45 && !fire9)
        {
            skeet3.yeetSkeet(power);
            fire9 = true;
            SkeetsLeft.SetText("Skeets Left: 6");
        }
        if (Time.timeSinceLevelLoad >= 50 && !fire10)
        {
            skeet1.yeetSkeet(power);
            fire10 = true;
            SkeetsLeft.SetText("Skeets Left: 5");
        }
        if (Time.timeSinceLevelLoad >= 55 && !fire11)
        {
            skeet2.yeetSkeet(power);
            fire11 = true;
            SkeetsLeft.SetText("Skeets Left: 4");
        }
        if (Time.timeSinceLevelLoad >= 60 && !fire12)
        {
            skeet3.yeetSkeet(power);
            fire12 = true;
            SkeetsLeft.SetText("Skeets Left: 3");
        }
        if (Time.timeSinceLevelLoad >= 65 && !fire13)
        {
            skeet1.yeetSkeet(power);
            fire13 = true;
            SkeetsLeft.SetText("Skeets Left: 2");
        }
        if (Time.timeSinceLevelLoad >= 70 && !fire14)
        {
            skeet2.yeetSkeet(power);
            fire14 = true;
            SkeetsLeft.SetText("Skeets Left: 1");
        }
        if (Time.timeSinceLevelLoad >= 75 && !fire15)
        {
            SkeetsLeft.enabled = false;
            skeet3.yeetSkeet(power);
            fire15 = true;
        }
        if(Time.timeSinceLevelLoad >= 80 || gun.shots >= gun.MaxShots)
        {
            Time.timeScale = 0f;
            BetterPauseMenu.disabled = true;
            scoreManger.EndGame();
        }

    }
    
}
