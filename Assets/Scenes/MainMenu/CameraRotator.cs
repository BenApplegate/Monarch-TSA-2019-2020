using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    public float speed;
   
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0); // You spin me right round baby right round like a record maybe round round round round
    }
}
