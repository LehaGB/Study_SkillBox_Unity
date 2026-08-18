using UnityEngine;

public static class TimeController 
{
    public static void Pause()
    {
        Time.timeScale = 0.0f;
    }


    public static void OnPause()
    {
        Time.timeScale = 1.0f;
    }
}
