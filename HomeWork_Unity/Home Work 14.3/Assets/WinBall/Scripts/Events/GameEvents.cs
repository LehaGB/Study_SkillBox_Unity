using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action OnPlayerWin;

    public static void RaisePlayerWin()
    {
        OnPlayerWin?.Invoke();
    }
}
