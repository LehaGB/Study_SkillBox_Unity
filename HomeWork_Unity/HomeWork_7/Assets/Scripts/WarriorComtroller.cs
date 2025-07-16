using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarriorComtroller : MonoBehaviour
{
    public GameManager gameManager;
    [HideInInspector]public ImageTimer warriorTimerTick;

    public SoundController soundController;

    public GameObject gameObjectScreen;

    public TextMeshProUGUI resourcesWarriorText;  // ���������� ������.
    public TextMeshProUGUI warriorNotEnoughWheat;  // ������������ �������.
    public TextMeshProUGUI warriorTimerText;   // ����������� ������ �������� �����.

    public Button warriorButton;  // ������ �����.
    public int warriorCount;   // ���������� ������.
    public int warriorCost;  // ��������� ����� �����.
    public float warriorCreateTime;  // ����� �������� �����.
    public int wheatToWarriors;  // ����������� ������� ������.

    private Image warriorTimerImg;

    private float _warriorTimer = -2;  // ����� �������� �������� �����.
    //private float a;
    private void Start()
    {
        //a = gameManager.harvestTimer.maxTime;
        UpdateText();
    }

    private void Update()
    {
        //a = warriorTimerTick.Timer();
        //warriorTimerText.text = Mathf.Round(a).ToString();
        CreateWarriorTime();
        if (warriorCount < 0)
        {
            soundController._audio.Stop();
            Time.timeScale = 0;
            gameManager.raidText.text = " ";
            gameManager.numberMovesAttackText.text = " ";
            gameObjectScreen.SetActive(true);
        }
    }

    public void CreateWarriorTime()
    {
        if (_warriorTimer > 0)
        {
            _warriorTimer -= Time.deltaTime;
             warriorTimerImg.fillAmount = _warriorTimer / warriorCreateTime;
            warriorTimerText.text = Mathf.Round(_warriorTimer).ToString();
        }
        else if (_warriorTimer > -1)
        {
            warriorTimerImg.fillAmount = 1;
            warriorButton.interactable = true;
            warriorCount += 1;
            _warriorTimer = -2;
            warriorTimerText.text = " ";
        }
        UpdateText();
    }

    public void CreateWarriorButton()
    {
        if (gameManager.wheatCount >= warriorCost)
        {
            warriorButton.interactable = true;
            gameManager.wheatCount -= warriorCost;
            _warriorTimer = warriorCreateTime;
            warriorNotEnoughWheat.text = "���������...";
            warriorButton.interactable = false;
        }
        else if(gameManager.wheatCount < warriorCost)
        {
            //_warriorTimer = warriorCreateTime;
            //warriorTimerText.text = Mathf.Round(a).ToString();
            warriorNotEnoughWheat.text = "������������ �������";
            warriorButton.interactable = false;
            
        }
        StartCoroutine(CoroutineWarriorNewText());
        StartCoroutine(CoroutineWarriorTimer());
    }

    private void UpdateText()
    {
        resourcesWarriorText.text = warriorCount.ToString();
    }
    IEnumerator CoroutineWarriorNewText()
    {
        yield return new WaitForSeconds(3f);
        warriorNotEnoughWheat.text = " ";
    }
    IEnumerator CoroutineWarriorTimer()
    {
        yield return new WaitForSeconds(3f);
        warriorButton.interactable = true;
    }
}
