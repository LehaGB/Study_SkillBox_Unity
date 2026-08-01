using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        if(CoinManager.instance != null)
        {
            Debug.Log("Подписались");
            CoinManager.instance.CoinCountChanged += UpdateText;
        }
        else
        {
            Debug.Log("CoinManager.instance == null");
        }
    }


    private void OnDisable()
    {
        CoinManager.instance.CoinCountChanged -= UpdateText;
    }

    public void UpdateText(int amount)
    {
        Debug.Log($"UpdateText: {amount}");
        coinText.text = $"Coin: {amount}";
    }
}
