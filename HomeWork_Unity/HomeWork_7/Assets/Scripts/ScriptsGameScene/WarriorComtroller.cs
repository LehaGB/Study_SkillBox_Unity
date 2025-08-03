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

    public TextMeshProUGUI resourcesWarriorText;  // количество воинов.
    public TextMeshProUGUI warriorNotEnoughWheat;  // недостаточно пшеницы.
    public TextMeshProUGUI warriorTimerText;   // Отоброжение секунд создания воина.


    public Button warriorButton;  // Нанять воина.
    public int warriorCount;   // количество воинов.
    public int warriorCost;  // стоимость найма воина.
    public float warriorCreateTime;  // время создания воина.
    public int wheatToWarriors;  // потребление пшеницы воином.
    public int saveWarriorsCount;  // Сохраняем количество воинов для VictoryGameController.
    
    private float _warriorTimer = -2;  // время ожидания создания воина.
    private float _warriorTimerIsNotWheat = -2;  // время ожидания когда мало пшеницы.

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


    // Когда проиграл.
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


    // Время создания воина.
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


    // Время, когда нет пшеницы.
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


    // Обновляем количество воинов.
    private void UpdateText()
    {
        resourcesWarriorText.text = warriorCount.ToString();
    }


    // Количество воинов.
    public int IncrementWarriorCount()
    {
        return saveWarriorsCount++;
    }


    // Количество воинов для GameManager.
    public int AddWarriorCount()
    {
        return warriorCount;
    }


    // Нажали кнопку.
    public void CreateWarriorButton()
    {
        if (gameManager.wheatCount >= warriorCost)
        {
            gameManager.wheatCount -= warriorCost;
            _warriorTimer = warriorCreateTime;
            warriorNotEnoughWheat.text = "Создается...";
            warriorButton.interactable = false;
            StartCoroutine(CoroutineWarriorTimer());
        }
        else if(gameManager.wheatCount < warriorCost)
        {
            _warriorTimerIsNotWheat = warriorCreateTime;
            warriorNotEnoughWheat.text = "Недостаточно пшеницы";
            warriorButton.interactable = false;
            StartCoroutine(CoroutineWarriorUpdateText());
        }  
    }

 
    // Обновляем текст и активируем кнопку.
    IEnumerator CoroutineWarriorUpdateText()
    {
        yield return new WaitForSeconds(4);
        warriorNotEnoughWheat.text = " ";
        warriorButton.interactable = true;
    }


    // Обновляем текст и активируем кнопку.
    IEnumerator CoroutineWarriorTimer()
    {
        yield return new WaitForSeconds(_warriorTimer);
        _audioSource.PlayOneShot(notificationClip);
        warriorNotEnoughWheat.text = " ";
        warriorButton.interactable = true;   
    }
}
