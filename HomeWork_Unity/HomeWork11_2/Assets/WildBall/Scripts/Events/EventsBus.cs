using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBus : MonoBehaviour
{
    public static EventsBus Instance { get; private set; }

    public event Action OnPlayerDied;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void TriggerPlayerDied()
    {
        OnPlayerDied?.Invoke();
    }
}
