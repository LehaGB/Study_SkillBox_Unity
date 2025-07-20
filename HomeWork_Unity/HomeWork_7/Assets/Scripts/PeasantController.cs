using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PeasantController : MonoBehaviour
{
    public GameManager gameManager;
    public Image peasantTimerImg;

    public TextMeshProUGUI resourcesPeasantText;  // количество крестьян.
    public TextMeshProUGUI peasantNotEnoughWheat;  // недостаточно пшеницы.
    public TextMeshProUGUI peasantTimerText;  // Отображение секунд создания крестьянина.

    public Button peasantButton;  // нанять крестьянина.

    public int peasantCount = 3;   // количество крестьян.
    public int wheatPerPeasant = 4;  // Увеличение сбора пшеницы.
    public int peasantCost = 4; // стоимость найма крестьянина.
    public float peasantCreateTime = 3;  // время создания крестьянина.

    private float _peasantTimer = -2;  // время ожидания создания крестьянина.
    private float _peasantTimerIsNotWheat = -2;  // время ожидания когда мало пшеницы.

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


    // Обновляем текст и активируем кнопку.
    IEnumerator CoroutinePeasantNewText()
    {
        yield return new WaitForSeconds(gameManager.harvestTimer.maxTime);
        peasantNotEnoughWheat.text = " ";
        peasantButton.interactable = true;
    }
    IEnumerator CoroutinePeasantTimer()
    {
        yield return new WaitForSeconds(_peasantTimer);
        PlayerPrefsManager.SavePeasantCount(peasantCount);
        peasantNotEnoughWheat.text = " ";
        peasantButton.interactable = true;
    }
}
