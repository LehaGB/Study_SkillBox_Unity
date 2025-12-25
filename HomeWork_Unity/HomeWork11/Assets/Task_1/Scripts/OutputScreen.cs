using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OutputScreen : MonoBehaviour
{
    public TextMeshProUGUI countCoinText;

    private PlayerController m_controller;
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
        m_controller = playerController;
        UdateCoinCount();
    }
    void Update()
    {
        if (m_controller != null && m_controller.m_IsActive)
        {
            UdateCoinCount();
        }
    }
    private void UdateCoinCount()
    {
        m_countCoinOutputScreen = m_controller.CountCoin;
        countCoinText.text = m_countCoinOutputScreen.ToString();
    }
}
