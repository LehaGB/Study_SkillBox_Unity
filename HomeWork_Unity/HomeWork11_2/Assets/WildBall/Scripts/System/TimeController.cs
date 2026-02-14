using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController 
{
    public void SetPauseOn()
    {
        Time.timeScale = 0;
        Debug.Log("Нажали Паузу");
    }
    public void SetPauseOff()
    {
        Time.timeScale = 1;
        Debug.Log("Нажали Играть");
    }
}
