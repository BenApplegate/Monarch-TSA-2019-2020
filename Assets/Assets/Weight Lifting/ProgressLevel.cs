using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressLevel : MonoBehaviour
{
    

    public float fillAmount = 5f;
    private Slider slider;

    private float targetProgress = 0;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Start()
    {
        IncrementProgress(0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            slider.value += fillAmount * Time.deltaTime;
        

        if (slider.value == 1f)
            Debug.Log("Game Done!");
        
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
