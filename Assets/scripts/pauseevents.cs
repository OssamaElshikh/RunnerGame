using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseevents : MonoBehaviour
{
    public PausePanel pausePanel;
    public void replaygame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitgame()
    {
        SceneManager.LoadScene("Menu");
    }
    public bool paused = false;
    public void ResumeGame()
    {
        pausePanel.ResumeGame();
    }


}
