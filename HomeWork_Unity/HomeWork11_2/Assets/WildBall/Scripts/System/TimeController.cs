using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class TimeController
{
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
