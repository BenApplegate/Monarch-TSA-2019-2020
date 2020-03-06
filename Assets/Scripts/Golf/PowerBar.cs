using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public float maxBar = 100f;
    public float startBar = 0f;
    public float increaseBar = 5f;
    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            slider.value = increaseBar;
        }
    }
}
