using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDontDestroy : MonoBehaviour
{
    public static AudioDontDestroy instance = null;
    private AudioSource _audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!= this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }
}
