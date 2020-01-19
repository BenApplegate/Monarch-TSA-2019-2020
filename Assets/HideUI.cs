using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HideUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI resultTargetHit;
    public Image crosshair;

    void Awake ()
    {
        crosshair.enabled = false;
    }

    void Start()
    {
        text.SetText("Use Left Click to Shoot");
        crosshair.enabled = true;
        resultTargetHit.SetText("");
    }

    void Update()
    {
        if(ShotCounter.shotsRemaining == 0f)
        {
            text.SetText("");
            crosshair.enabled = false;
        }
        else
        {
            return;
        }
    }


}
