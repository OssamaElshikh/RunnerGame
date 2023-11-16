using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class events : MonoBehaviour

{
   
public void replaygame()
    {

        
        SceneManager.LoadScene("SampleScene");
    }

public void quitgame()
    {
        Debug.Log("hii");
        SceneManager.LoadScene("Menu");
    }
    public bool paused = false;
    public void ResumeGame()
    {
        Time.timeScale = 1.0f; // Resume the game by setting time scale to 1
        gameObject.SetActive(false); // Hide the pause panel
    }
 
}
