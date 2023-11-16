using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class optionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Mute()
    {
        AudioListener.volume = 0f;
    }
}
