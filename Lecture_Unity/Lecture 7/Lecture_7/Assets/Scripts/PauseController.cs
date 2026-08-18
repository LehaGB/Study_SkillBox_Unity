using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    public AudioSource sound;
    private bool _isPuased;

    public void PauseGame()
    {
        if (_isPuased)
        {
            Time.timeScale = 1;
            sound.Play();
        }
        else
        {
            Time.timeScale = 0;
            sound.Pause();
        }
        _isPuased = !_isPuased;
    }
}
