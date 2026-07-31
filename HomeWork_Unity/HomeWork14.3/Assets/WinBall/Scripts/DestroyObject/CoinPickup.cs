using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        CoinManager.instance.AddCoin(1);

        Destroy(gameObject);
    }
}
