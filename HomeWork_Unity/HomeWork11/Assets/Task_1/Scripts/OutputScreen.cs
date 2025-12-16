using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutputScreen : MonoBehaviour
{
    public TextMeshProUGUI countCoinText;

    private PlayerController m_controller;
      

    // Start is called before the first frame update
    void Start()
    {
        m_controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_controller.m_IsActive)
        {
            countCoinText.text = $"{m_controller.CountCoin}";
        }
    }
}
