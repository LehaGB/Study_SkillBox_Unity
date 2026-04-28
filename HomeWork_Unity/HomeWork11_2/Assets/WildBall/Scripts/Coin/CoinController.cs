using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject coin;

    private void OnEnable()
    {
        EventsBus.Instance.OnCoinDestroy += CoinDestroy;
    }


    private void OnDestroy()
    {
        EventsBus.Instance.OnCoinDestroy -= CoinDestroy;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinDestroy();
        }    
    }

    private void CoinDestroy()
    {
        Destroy(coin);
    }
}
