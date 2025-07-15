using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarriorComtroller : MonoBehaviour
{
    public GameManager gameManager;
    //public ImageTimer imageTimer;

    public SoundController soundController;

    public GameObject gameObjectScreen;

    public TextMeshProUGUI resourcesWarriorText;  // ���������� ������.
    public TextMeshProUGUI warriorNotEnoughWheat;  // ������������ �������.
    public TextMeshProUGUI warriorTimerText;   // ����������� ������ �������� �����.

    public Image warriorTimerImg;

    public Button warriorButton;  // ������ �����.
    public int warriorCount;   // ���������� ������.
    public int warriorCost;  // ��������� ����� �����.
    public float warriorCreateTime;  // ����� �������� �����.
    public int wheatToWarriors;  // ����������� ������� ������.

    private float _warriorTimer = -2;  // ����� �������� �������� �����.

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
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
            gameManager.wheatCount -= warriorCost;
            _warriorTimer = warriorCreateTime;
            warriorNotEnoughWheat.text = "���������...";
            warriorButton.interactable = false;
        }
        else if(gameManager.wheatCount < warriorCost)
        {
            warriorNotEnoughWheat.text = "������������ �������";
            warriorButton.interactable = false;
            
        }
        StartCoroutine(CoroutineWarriorCountText());
    }

    private void UpdateText()
    {
        resourcesWarriorText.text = warriorCount.ToString();
    }
    IEnumerator CoroutineWarriorCountText()
    {
        yield return new WaitForSeconds(1);
        warriorNotEnoughWheat.text = " ";
        warriorButton.interactable = true;
    }
}
