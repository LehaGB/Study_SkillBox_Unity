using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PeasantController : MonoBehaviour
{
    public GameManager gameManager;
    public Image peasantTimerImg;
    public LoadScene loadScene;
    public SoundController soundController;

    public GameObject gameScene;
    public GameObject gameVictory;

    public TextMeshProUGUI resourcesPeasantText;  // ���������� ��������.
    public TextMeshProUGUI peasantNotEnoughWheat;  // ������������ �������.
    public TextMeshProUGUI peasantTimerText;  // ����������� ������ �������� �����������.

    public Button peasantButton;  // ������ �����������.
    public int createPeasantCount { get; private set; } = 0;  // ������� ��������.

    public int peasantCount = 3;   // ���������� ��������.
    public int wheatPerPeasant = 4;  // ���������� ����� �������.
    public int peasantCost = 4; // ��������� ����� �����������.
    public float peasantCreateTime = 3;  // ����� �������� �����������.

    private float _peasantTimer = -2;  // ����� �������� �������� �����������.
    private float _peasantTimerIsNotWheat = -2;  // ����� �������� ����� ���� �������.
    private int _maxCountPeasantforVictory = 5;


    private void Start()
    {
        createPeasantCount = peasantCount;
    }


    private void Update()
    {
        CreatePeasantTime();
        IsNotEnoughWheatTimer();
    }


    // ����� ����� �����������.
    public void CreatePeasantTime()
    {
        if (_peasantTimer > 0)
        {
            _peasantTimer -= Time.deltaTime;
            peasantTimerImg.fillAmount = _peasantTimer / peasantCreateTime;
            peasantTimerText.text = $"{Mathf.Round(_peasantTimer)}";
        }
        else if (_peasantTimer > -1)
        {
            peasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            _peasantTimer = -2;
            peasantTimerText.text = " ";
        }
        if(peasantCount == _maxCountPeasantforVictory)
        {
            soundController._audio.Stop();
            Time.timeScale = 0;
            gameScene.SetActive(false);
            gameVictory.SetActive(true);
        }
        UpdateText();
    }


    // ����� ����� ������� �� �������.
    public void IsNotEnoughWheatTimer()
    {
        if (_peasantTimerIsNotWheat > 0)
        {
            _peasantTimerIsNotWheat -= Time.deltaTime;
            peasantTimerImg.fillAmount = _peasantTimerIsNotWheat / peasantCreateTime;
            peasantTimerText.text = $"{Mathf.Round(_peasantTimerIsNotWheat)}";
        }
        else if (_peasantTimerIsNotWheat > -1)
        {
            _peasantTimerIsNotWheat = -2;
            peasantTimerText.text = " ";
        }
        UpdateText();
    }


    // ������ �� ������.
    public void CreatePeasantButton()
    {
        if(gameManager.wheatCount >= peasantCost)
        {
            gameManager.wheatCount -= peasantCost;
            _peasantTimer = peasantCreateTime;
            peasantNotEnoughWheat.text = "���������...";
            peasantButton.interactable = false;
            AddPeasantCount();
            StartCoroutine(CoroutinePeasantTimer());
        }
        else if(gameManager.wheatCount < peasantCost)
        {
            _peasantTimerIsNotWheat = peasantCreateTime;
            peasantNotEnoughWheat.text = "������������ �������";
            peasantButton.interactable = false;
            StartCoroutine(CoroutinePeasantNewText());
        } 
    }


    // ��������� ���������� ��������.
    public void UpdateText()
    {
        resourcesPeasantText.text = peasantCount.ToString();
    }


    // ���������� �������� ��� GameOver.
    public int AddPeasantCount()
    {
        return createPeasantCount ++;
    }


    // ��������� ����� � ���������� ������.
    IEnumerator CoroutinePeasantNewText()
    {
        yield return new WaitForSeconds(4);
        peasantNotEnoughWheat.text = " ";
        peasantButton.interactable = true;
    }


    // ���������� ������ � ��������� �����.
    IEnumerator CoroutinePeasantTimer()
    {
        yield return new WaitForSeconds(_peasantTimer);
        peasantNotEnoughWheat.text = " ";
        peasantButton.interactable = true;
    }
}
