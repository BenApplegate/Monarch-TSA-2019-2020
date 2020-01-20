using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowingStart : MonoBehaviour
{
    public Text txt;
    float time = 0f;

    public Score sc;
    public coxswain cox;
    public Countdown ct;
    public CameraMove cm;

    // Start is called before the first frame update
    void Start()
    {
        sc.enabled = false;
        cox.enabled = false;
        ct.enabled = false;
        cm.enabled = false;
    }

    // Update is called once per frame
    void  Update()
    {
        time = Time.timeSinceLevelLoad;
        if (time <= 1)
        {
            txt.text = "Ready";
        }
        else if (time <= 2)
        {
            txt.text = "Set";
        }
        else if (time <= 3)
        {
            txt.text = "Row";
        }
        else if (time > 4)
        {
            txt.enabled = false;
            sc.enabled = true;
            cox.enabled = true;
            ct.enabled = true;
            cm.enabled = true;
        }

    }
}
