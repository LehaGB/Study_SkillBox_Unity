using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance {  get; private set; }
    private int countCoin = 0;

    public int CoinCount { get => countCoin; set => countCoin = value; }
    public event Action<int> CoinCountChanged;


    private void Awake()
    {
        Debug.Log("CoinManager Awake");
        if (instance != null && instance != this)
        {
            Debug.Log("Второй CoinManager уничтожен");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void AddCoin(int amount)
    {
        countCoin = countCoin + amount;
        Debug.Log($"Coin = {countCoin}");

        CoinCountChanged?.Invoke(countCoin);
        Debug.Log($"{amount} {CoinCount}");
    }
}
