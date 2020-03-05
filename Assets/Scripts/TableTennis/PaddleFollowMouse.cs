using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleFollowMouse : MonoBehaviour
{

    public float distance = 1f;
    public bool useCameraDistance = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float actualDistance;
        if(useCameraDistance)
        {
            actualDistance = (transform.position - Camera.main.transform.position).magnitude;
        }
        else
        {
            actualDistance = distance;
        }
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = distance;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
