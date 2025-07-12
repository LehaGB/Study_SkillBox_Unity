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

    public TextMeshProUGUI resourcesWarriorText;  // количество воинов.

    public Image warriorTimerImg;

    public Button warriorButton;  // Ќан€ть воина.
    public int warriorCount;   // количество воинов.
    public int warriorCost;  // стоимость найма воина.
    public float warriorCreateTime;  // врем€ создани€ воина.
    private float _warriorTimer = -2;  // врем€ ожидани€ создани€ воина.
    public int wheatToWarriors;  // потребление пшеницы воином.

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
