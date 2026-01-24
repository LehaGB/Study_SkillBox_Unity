using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OutputScreen : MonoBehaviour
{
    public TextMeshProUGUI countCoinText;

    private PlayerController _controller;
    private int m_countCoinOutputScreen;

    private void OnEnable()
    {
        CreatePLayer.OnPlayerCreated += HandlePlayerCreated;
    }
    private void OnDisable()
    {
        CreatePLayer.OnPlayerCreated -= HandlePlayerCreated;
    }

    private void HandlePlayerCreated(PlayerController playerController)
    {
        _controller = playerController;
        UdateCoinCount();
    }
    void Update()
    {
        if (_controller != null)
        {
            UdateCoinCount();
        }
    }
    private void UdateCoinCount()
    {
        m_countCoinOutputScreen = _controller.CountCoin;
        countCoinText.text = m_countCoinOutputScreen.ToString();
    }
}
