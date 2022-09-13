using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgMusic;
    public AudioSource startMusic;
    public AudioSource clickMusic;

    public void PlayMouseClickSound()
    {
        clickMusic.Play();
    }
}
