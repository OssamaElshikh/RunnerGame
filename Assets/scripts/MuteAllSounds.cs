using UnityEngine;

public class MuteAllSounds : MonoBehaviour
{

    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted; // Toggle the mute state

        if (isMuted)
        {
            AudioListener.volume = 0f; // Mute all sounds
        }
        else
        {
            AudioListener.volume = 1f; // Unmute all sounds
        }
    }
}