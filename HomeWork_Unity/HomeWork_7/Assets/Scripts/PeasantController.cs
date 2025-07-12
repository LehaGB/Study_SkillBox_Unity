using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PeasantController : MonoBehaviour
{
    public GameManager gameManager;
    public Image peasantTimerImg;

    public TextMeshProUGUI resourcesPeasantText;  // ���������� ��������.
    
    public Button peasantButton;  // ������ �����������.

    public int peasantCount = 3;   // ���������� ��������.
    public int wheatPerPeasant = 4;  // ���������� ��������.
    public int peasantCost = 4; // ��������� ����� �����������.
    public float peasantCreateTime = 3;  // ����� �������� �����������.
    //public int wheatCount = 20;  // ��������� �������.

    private float _peasantTimer = -2;  // ����� �������� �������� �����������.

    public void CreatePeasantTime()
    {
       
        if (_peasantTimer > 0)
        {
            _peasantTimer -= Time.deltaTime;
            peasantTimerImg.fillAmount = _peasantTimer / peasantCreateTime;
        }
        else if (_peasantTimer > -1)
        {
            peasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            _peasantTimer = -2;
        }
        UpdateText();
    }
    public void CreatePeasantButton()
    {
        gameManager.wheatCount -= peasantCost;
        _peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;
    }
    public void UpdateText()
    {
        resourcesPeasantText.text = peasantCount.ToString();
    }
}
