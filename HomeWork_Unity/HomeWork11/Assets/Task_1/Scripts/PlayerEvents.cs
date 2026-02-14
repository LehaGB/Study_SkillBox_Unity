using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void CoinCollected(int coin);
    public static event CoinCollected OnCoinCollected;

    public delegate void PlayerFell();
    public static event PlayerFell OnPlayerFell;

    private int _countCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            _countCoin++;
            OnCoinCollected?.Invoke(_countCoin);
        }
    }
    public void CheckFall(float yPostion)
    {
        OnPlayerFell?.Invoke();
    }
}
