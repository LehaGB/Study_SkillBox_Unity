using System;
using UnityEngine;

public class PlayersDeath : MonoBehaviour
{
    private void OnEnable()
    {
        if (EventsBus.Instance != null)
        {
            EventsBus.Instance.OnPlayerDied += HandlePlayerDeathEvent;
        }           
    }

    private void OnDisable()
    {
        // Отписка при отключении объекта
        if (EventsBus.Instance != null)
        {
            EventsBus.Instance.OnPlayerDied -= HandlePlayerDeathEvent;
        }
    }

    private void HandlePlayerDeathEvent()   
    {
        Destroy(this.gameObject);
    }
}
