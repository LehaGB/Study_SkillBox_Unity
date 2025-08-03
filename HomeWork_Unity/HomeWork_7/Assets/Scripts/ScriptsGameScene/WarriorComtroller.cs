using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarriorComtroller : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject gameOver;
    public GameObject gameScene;

    public SoundController soundController;
    public AudioClip notificationClip;

    public Image warriorTimerImg;

    public TextMeshProUGUI resourcesWarriorText;  // ���������� ������.
    public TextMeshProUGUI warriorNotEnoughWheat;  // ������������ �������.
    public TextMeshProUGUI warriorTimerText;   // ����������� ������ �������� �����.


    public Button warriorButton;  // ������ �����.
    public int warriorCount;   // ���������� ������.
    public int warriorCost;  // ��������� ����� �����.
    public float warriorCreateTime;  // ����� �������� �����.
    public int wheatToWarriors;  // ����������� ������� ������.
    public int saveWarriorsCount;  // ��������� ���������� ������ ��� VictoryGameController.
    
    private float _warriorTimer = -2;  // ����� �������� �������� �����.
    private float _warriorTimerIsNotWheat = -2;  // ����� �������� ����� ���� �������.

    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        UpdateText();
    }


    private void Update()
    {
        CreateWarriorTime();
        IsNotEnoughWheatTimer();
        GameOverWarriorFalle();
    }


    // ����� ��������.
    public void GameOverWarriorFalle()
    {
        if (warriorCount < 0)
        {
            soundController._audio.Stop();
            Time.timeScale = 0;
            gameManager.raidText.text = " ";
            gameManager.numberMovesAttackText.text = " ";
            gameScene.SetActive(false);
            gameOver.SetActive(true);
        }
    }


    // ����� �������� �����.
    public void CreateWarriorTime()
    {
        if (_warriorTimer > 0)
        {
            _warriorTimer -= Time.deltaTime;
             warriorTimerImg.fillAmount = _warriorTimer / warriorCreateTime;
            warriorTimerText.text = $"{Mathf.Round(_warriorTimer)}";
        }
        else if (_warriorTimer > -1)
        {
            warriorTimerImg.fillAmount = 1;
            warriorButton.interactable = true;
            warriorCount += 1;
            IncrementWarriorCount();
            _warriorTimer = -2;
            warriorTimerText.text = " ";
        }
        UpdateText();
    }


    // �����, ����� ��� �������.
    public void IsNotEnoughWheatTimer()
    {
        if(_warriorTimerIsNotWheat > 0)
        {
            _warriorTimerIsNotWheat -= Time.deltaTime;
            warriorTimerImg.fillAmount = _warriorTimerIsNotWheat / warriorCreateTime;
            warriorTimerText.text = $"{Mathf.Round(_warriorTimerIsNotWheat)}";
        }
        else if (_warriorTimerIsNotWheat > -1)
        {
            warriorTimerImg.fillAmount = 1;
            _warriorTimerIsNotWheat = -2;
            warriorTimerText.text = " ";
        }
        UpdateText();
    }


    // ��������� ���������� ������.
    private void UpdateText()
    {
        resourcesWarriorText.text = warriorCount.ToString();
    }


    // ���������� ������.
    public int IncrementWarriorCount()
    {
        return saveWarriorsCount++;
    }


    // ���������� ������ ��� GameManager.
    public int AddWarriorCount()
    {
        return warriorCount;
    }


    // ������ ������.
    public void CreateWarriorButton()
    {
        if (gameManager.wheatCount >= warriorCost)
        {
            gameManager.wheatCount -= warriorCost;
            _warriorTimer = warriorCreateTime;
            warriorNotEnoughWheat.text = "���������...";
            warriorButton.interactable = false;
            StartCoroutine(CoroutineWarriorTimer());
        }
        else if(gameManager.wheatCount < warriorCost)
        {
            _warriorTimerIsNotWheat = warriorCreateTime;
            warriorNotEnoughWheat.text = "������������ �������";
            warriorButton.interactable = false;
            StartCoroutine(CoroutineWarriorUpdateText());
        }  
    }

 
    // ��������� ����� � ���������� ������.
    IEnumerator CoroutineWarriorUpdateText()
    {
        yield return new WaitForSeconds(4);
        warriorNotEnoughWheat.text = " ";
        warriorButton.interactable = true;
    }


    // ��������� ����� � ���������� ������.
    IEnumerator CoroutineWarriorTimer()
    {
        yield return new WaitForSeconds(_warriorTimer);
        _audioSource.PlayOneShot(notificationClip);
        warriorNotEnoughWheat.text = " ";
        warriorButton.interactable = true;   
    }
}
