using UnityEngine;

public class CollectedCoins : MonoBehaviour
{
    private int countCoin = 0;

    public int Coin { get { return countCoin; } set { countCoin = value; } }

    private void OnEnable()
    {
        ActionCollectedCoins.CollectedCoinsChanged += CountCoin;
    }

    private void OnDisable()
    {
        ActionCollectedCoins.CollectedCoinsChanged -= CountCoin;
    }

    public void CountCoin()
    {
        Coin++;
        Debug.Log($"Coin = {countCoin}");
    }
}
