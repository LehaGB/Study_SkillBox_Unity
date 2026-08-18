using UnityEngine;
using TMPro;
using System;

public class WinText : MonoBehaviour
{
    public TextMeshProUGUI winText;

    private void OnEnable()
    {
        GameEvents.OnPlayerWin += ShowWin;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerWin -= ShowWin;
    }

    private void Start()
    {
        Hide();
    }

    private void ShowWin()
    {
        winText.gameObject.SetActive(true);
        winText.text = "You Win!";
    }

    private void Hide()
    {
        winText.gameObject.SetActive(false);
        winText.text = "";
    }
}
