using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public Image raidTimerImg;
    public Image peasantTimerImg;
    public Image warriorTimerImg;

    public GameObject gameObjectScreen;

    public TextMeshProUGUI resourcesText;  // количество ресурсов.

    public Button peasantButton;  // Ќан€ть кресть€нина.
    public Button warriorButton;  // Ќан€ть воина.

    public int peasantCount;   // количество кресть€н.
    public int warriorCount;   // количество воинов.
    public int wheatCount;  // коичество пшеницы.

    public int wheatPerPeasant;  // сбор пшеницы кресть€нином.
    public int wheatToWarriors;  // потребление пшеницы воином.

    public int peasantCost;  // стоимость найма кресть€нина.
    public int warriorCost;  // стоимость найма воина.

    public float peasantCreateTime;  // врем€ создани€ кресть€нина.
    public float warriorCreateTime;  // врем€ создани€ воина.
    public float raidMaxTime;  // врем€ наступлени€ рейда.
    public int raidIncrease;  // увеличение рейда.
    public int nextRaid;   // следующий рейд.

    private float _peasantTimer = -2;  // врем€ ожидани€ создани€ кресть€нина.
    private float _warriorTimer = -2;  // врем€ ожидани€ создани€ воина.
    private float _raidTimer;  // врем€ ожидани€ набега.

    private void Start()
    {
        UpdateText();
        _raidTimer = raidMaxTime;
    }

    private void Update()
    {
        _raidTimer -= Time.deltaTime;
        raidTimerImg.fillAmount = _raidTimer / raidMaxTime;

        if(_raidTimer <= 0)
        {
            _raidTimer = raidMaxTime;
            warriorCount -= nextRaid;
            nextRaid += raidIncrease;
        }

        if (harvestTimer.tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
        }

        if (eatingTimer.tick)
        {
            wheatCount -= warriorCount * wheatToWarriors;
        }

        if(_peasantTimer > 0)
        {
            _peasantTimer -= Time.deltaTime;
            peasantTimerImg.fillAmount = _peasantTimer / peasantCreateTime;
        }
        else if(_peasantTimer > -1)
        {
            peasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            _peasantTimer = -2;
        }
        if(_warriorTimer > 0)
        {
            _warriorTimer -= Time.deltaTime;
            warriorTimerImg.fillAmount = _warriorTimer / warriorCreateTime;
        }
        else if(_warriorTimer > -1)
        {
            warriorTimerImg.fillAmount = 1;
            warriorButton.interactable = true;
            warriorCount += 1;
            _warriorTimer = -2;
        }
        UpdateText();

        if(warriorCount < 0)
        {
            Time.timeScale = 0;
            gameObjectScreen.SetActive(true);
        }
    }

    public void CreatePeasant()
    {
        wheatCount -= peasantCost;
        _peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;
    }

    public void CreateWarriors()
    {
        wheatCount -= warriorCost;
        _warriorTimer = warriorCreateTime;
        warriorButton.interactable = false;
    }

    private void UpdateText()
    {
        resourcesText.text = peasantCount + "\n" + warriorCount + "\n\n" + wheatCount;
    }
}
