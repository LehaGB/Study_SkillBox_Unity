using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarriorComtroller : MonoBehaviour
{
    public GameManager gameManager;
    public SoundController soundController;

    public GameObject gameObjectScreen;

    public TextMeshProUGUI resourcesWarriorText;  // ���������� ������.

    public Image warriorTimerImg;

    public Button warriorButton;  // ������ �����.
    public int warriorCount;   // ���������� ������.
    public int warriorCost;  // ��������� ����� �����.
    public float warriorCreateTime;  // ����� �������� �����.
    private float _warriorTimer = -2;  // ����� �������� �������� �����.
    public int wheatToWarriors;  // ����������� ������� ������.

    public void CreateWarriorTime()
    {
        if (_warriorTimer > 0)
        {
            _warriorTimer -= Time.deltaTime;
            warriorTimerImg.fillAmount = _warriorTimer / warriorCreateTime;
        }
        else if (_warriorTimer > -1)
        {
            warriorTimerImg.fillAmount = 1;
            warriorButton.interactable = true;
            warriorCount += 1;
            _warriorTimer = -2;
        }
        UpdateText();

        if (warriorCount < 0)
        {
            soundController._audio.Stop();
            Time.timeScale = 0;
            gameManager.raidText.text = " ";
            gameManager.numberMovesAttackText.text = " ";
            gameObjectScreen.SetActive(true);
        }
    }
    public void CreateWarriors()
    {
        gameManager.wheatCount -= warriorCost;
        _warriorTimer = warriorCreateTime;
        warriorButton.interactable = false;
    }

    private void UpdateText()
    {
        resourcesWarriorText.text = warriorCount.ToString();
    }
}
