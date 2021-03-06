﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDontDestroy : MonoBehaviour
{
    public static AudioDontDestroy instance = null;
   
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
