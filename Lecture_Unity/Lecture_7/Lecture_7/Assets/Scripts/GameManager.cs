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

    public TextMeshProUGUI resourcesText;  // ���������� ��������.

    public Button peasantButton;  // ������ �����������.
    public Button warriorButton;  // ������ �����.

    public int peasantCount;   // ���������� ��������.
    public int warriorCount;   // ���������� ������.
    public int wheatCount;  // ��������� �������.

    public int wheatPerPeasant;  // ���� ������� ������������.
    public int wheatToWarriors;  // ����������� ������� ������.

    public int peasantCost;  // ��������� ����� �����������.
    public int warriorCost;  // ��������� ����� �����.

    public float peasantCreateTime;  // ����� �������� �����������.
    public float warriorCreateTime;  // ����� �������� �����.
    public float raidMaxTime;  // ����� ����������� �����.
    public int raidIncrease;  // ���������� �����.
    public int nextRaid;   // ��������� ����.

    private float _peasantTimer = -2;  // ����� �������� �������� �����������.
    private float _warriorTimer = -2;  // ����� �������� �������� �����.
    private float _raidTimer;  // ����� �������� ������.

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
