using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio Sources
    public AudioSource menuMusic, gameMusic;

    // Script References
    public GameManager gameManager;

    public void PlayMenuMusic()
    {
        gameMusic.Stop();
        menuMusic.Play();
    }
    
    public void PlayGameMusic()
    {
        menuMusic.Stop();
        gameMusic.Play();
    }
}
