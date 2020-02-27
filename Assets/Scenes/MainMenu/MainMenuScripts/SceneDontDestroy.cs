using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDontDestroy : MonoBehaviour
{
    public static SceneDontDestroy instance = null;
   
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
