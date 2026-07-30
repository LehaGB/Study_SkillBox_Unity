using System;
using UnityEngine;

public class ActionCollectedCoins : MonoBehaviour
{
    public static event Action CollectedCoinsChanged;


    public static void HandleCollectedCoins()
    {
        CollectedCoinsChanged?.Invoke();
    }
}
