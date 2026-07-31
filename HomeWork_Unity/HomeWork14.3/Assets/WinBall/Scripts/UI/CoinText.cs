using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        CoinManager.instance.CoinCountChanged += UpdateText;
    }


    private void OnDisable()
    {
        CoinManager.instance.CoinCountChanged -= UpdateText;
    }

    public void UpdateText(int amout)
    {
        coinText.text = $"Coin: {amout}";
    }
}
