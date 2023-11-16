using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverscript : MonoBehaviour
{
    public static bool gameover;
    public GameObject gamepanel;
    public AudioSource backgroundAudioSource;

    void Start() 
    {
        gameover = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
            gamepanel.SetActive(true);
            if (backgroundAudioSource != null)
            {
                backgroundAudioSource.Pause(); // Use Pause to resume playback later
                // OR
                // backgroundAudioSource.Stop(); // Use Stop to stop playback completely
            }
        }

    }
}
