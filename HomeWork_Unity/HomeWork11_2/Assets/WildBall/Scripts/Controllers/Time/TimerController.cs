using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour 
{
    private void OnEnable()
    {
        if(EventsBus.Instance != null)
        {
            EventsBus.Instance.OnPlayerDied += SetPauseOn;
        }
    }
    private void OnDestroy()
    {
        if (EventsBus.Instance != null)
        {
            EventsBus.Instance.OnPlayerDied -= SetPauseOn;
        }
    }

    public void SetPauseOn()
    {
        Time.timeScale = 0;
        Debug.Log("Нажали Паузу");
        Debug.Log("Стоп музыка TimeController");
    }
    public void SetPauseOff()
    {
        Time.timeScale = 1;
        Debug.Log("Нажали Играть");
        Debug.Log("Играет музыка");
    }
}
