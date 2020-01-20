using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{


    public AudioMixer audioMixer;

    public void SetVolume (float volume) { // Set Volume to the Game, Audio Slider not yet made
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen (bool isFullScreen) // Toggles Fullscreen, window not resizeable. But has a way of exiting
    {
        Screen.fullScreen = isFullScreen;
    }

    
}
