using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutputScreen : MonoBehaviour
{
    public TextMeshProUGUI countCoinText;

    public PlayerController m_controller;
    private int m_countCoinOutputScreen;

    // Start is called before the first frame update
    void Start()
    {
        m_controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_controller != null && m_controller.m_IsActive)
        {
            m_countCoinOutputScreen = m_controller.CountCoin;
            countCoinText.text = m_countCoinOutputScreen.ToString();
            Debug.Log(m_countCoinOutputScreen.ToString());
        }
    }
}
