using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{

    public Slider slider;
    public AudioSource audio;

    private void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("voloume"))
        {
            PlayerPrefs.SetFloat("voloume", .1f);
        }
        audio.volume = PlayerPrefs.GetFloat("voloume");
    }

    private void Start()
    {
        
        slider.value = PlayerPrefs.GetFloat("voloume");
        
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("voloume", audio.volume);
    }

    public void SetVolume (float vol) { // Set Volume to the Game, Audio Slider not yet made
        audio.volume = vol;
    }

    public void SetFullScreen (bool isFullScreen) // Toggles Fullscreen, window not resizeable. But has a way of exiting
    {
        Screen.fullScreen = isFullScreen;
        
    }

    
}
