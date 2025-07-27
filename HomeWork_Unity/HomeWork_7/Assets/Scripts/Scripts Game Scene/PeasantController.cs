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

    public TextMeshProUGUI resourcesPeasantText;  // количество крестьян.
    public TextMeshProUGUI peasantNotEnoughWheat;  // недостаточно пшеницы.
    public TextMeshProUGUI peasantTimerText;  // Отображение секунд создания крестьянина.

    public Button peasantButton;  // нанять крестьянина.
    public int createPeasantCount { get; private set; } = 0;  // Создано крестьян.

    public int peasantCount = 3;   // количество крестьян.
    public int wheatPerPeasant = 4;  // Увеличение сбора пшеницы.
    public int peasantCost = 4; // стоимость найма крестьянина.
    public float peasantCreateTime = 3;  // время создания крестьянина.

    private float _peasantTimer = -2;  // время ожидания создания крестьянина.
    private float _peasantTimerIsNotWheat = -2;  // время ожидания когда мало пшеницы.
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


    // Время найма крестьянина.
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


    // Время когда пшеницы не хватает.
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


    // Нажали на кнопку.
    public void CreatePeasantButton()
    {
        if(gameManager.wheatCount >= peasantCost)
        {
            gameManager.wheatCount -= peasantCost;
            _peasantTimer = peasantCreateTime;
            peasantNotEnoughWheat.text = "Создается...";
            peasantButton.interactable = false;
            AddPeasantCount();
            StartCoroutine(CoroutinePeasantTimer());
        }
        else if(gameManager.wheatCount < peasantCost)
        {
            _peasantTimerIsNotWheat = peasantCreateTime;
            peasantNotEnoughWheat.text = "Недостаточно пшеницы";
            peasantButton.interactable = false;
            StartCoroutine(CoroutinePeasantNewText());
        } 
    }


    // Обновляем количество крестьян.
    public void UpdateText()
    {
        resourcesPeasantText.text = peasantCount.ToString();
    }


    // Количество крестьян для GameOver.
    public int AddPeasantCount()
    {
        return createPeasantCount ++;
    }


    // Обновляем текст и активируем кнопку.
    IEnumerator CoroutinePeasantNewText()
    {
        yield return new WaitForSeconds(4);
        peasantNotEnoughWheat.text = " ";
        peasantButton.interactable = true;
    }


    // Активируем кнопку и обновляем текст.
    IEnumerator CoroutinePeasantTimer()
    {
        yield return new WaitForSeconds(_peasantTimer);
        peasantNotEnoughWheat.text = " ";
        peasantButton.interactable = true;
    }
}
