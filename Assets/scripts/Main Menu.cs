using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void options()
    {
        SceneManager.LoadScene("Options");
    }
}
