using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public ParticalController particalController;

    private void OnEnable()
    {
        if(EventsBus.Instance != null)
        {
            EventsBus.Instance.OnCoinDestroy += CoinDestroy;
        }
    }


    private void OnDestroy()
    {
        if (EventsBus.Instance != null)
        {
            EventsBus.Instance.OnCoinDestroy -= CoinDestroy;
        }
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
        particalController.IsActiveExplosion();
        Destroy(this.gameObject);
    }
}
