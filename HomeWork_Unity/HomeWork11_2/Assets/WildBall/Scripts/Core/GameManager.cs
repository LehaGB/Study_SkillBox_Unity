using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private bool isPaused = false;

    public void PauseGame() 
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    public void ResumeGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
