using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    
    
    public Image GreenProgressBar;
    public int maxProgress = 100;
    public int currentProgress = 0;


    void Start () 
    {
        GreenProgressBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update(int valueUp)
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GreenProgressBar.fillAmount = 0.1f;
        }

    }
}
