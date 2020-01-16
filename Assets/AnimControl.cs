using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public Animation anim;


    // Start is called before the first frame update
    void Start()
    {
        anim["Lifting"].time = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
