using Unity.VisualScripting;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnEnable()
    {
        ActionCollectedCoins.CollectedCoinsChanged += OnDestroyCoin;
    }


    private void OnDisable()
    {
        ActionCollectedCoins.CollectedCoinsChanged -= OnDestroyCoin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //ActionCollectedCoins.HandleCollectedCoins();
            OnDestroyCoin();
        }
    }

    public void OnDestroyCoin()
    {
        Destroy(gameObject);
    }
}
