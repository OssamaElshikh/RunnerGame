using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public bool isPaused = false;

    // Reference to the pause panel GameObject
    public GameObject pausePanel;
    public static bool gameover;
    

    private void Start()
    {
        // Ensure the pause panel is initially hidden
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Pause the game by setting time scale to 0
        pausePanel.SetActive(true); // Show the pause panel
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f; // Resume the game by setting time scale to 1
        pausePanel.SetActive(false); // Hide the pause panel
    }

    public void RestartGame()
    {
        
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

