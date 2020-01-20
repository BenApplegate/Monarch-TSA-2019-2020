using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Update is called once per frame
    private int movingSpeed = -4;
    private int fasterSpeed = 0;
    bool faster = false;
    int count = 60;
    void Update()
    {

        if (faster && count < 40)
        {
            transform.position += Vector3.right * Time.deltaTime * fasterSpeed;
            count++;
        }
        else
        {
            transform.position += Vector3.right * Time.deltaTime * movingSpeed;
        }

    }

    public void GoFaster(int speed)
    {
        fasterSpeed = speed;
        count = 0;
        faster = true;
    }

    

}