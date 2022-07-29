using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio Sources
    public AudioSource menuMusic, gameMusic;

    // Script References
    public GameManager gameManager;

    private bool isMenuMusicPlaying;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
