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

    public TextMeshProUGUI resourcesWarriorText;  // количество воинов.
    public TextMeshProUGUI warriorNotEnoughWheat;  // недостаточно пшеницы.
    public TextMeshProUGUI warriorTimerText;   // Отоброжение секунд создания воина.

    public Image warriorTimerImg;

    public Button warriorButton;  // Нанять воина.
    public int warriorCount;   // количество воинов.
    public int warriorCost;  // стоимость найма воина.
    public float warriorCreateTime;  // время создания воина.
    public int wheatToWarriors;  // потребление пшеницы воином.

    private float _warriorTimer = -2;  // время ожидания создания воина.

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
            warriorNotEnoughWheat.text = "Создается...";
            warriorButton.interactable = false;
        }
        else if(gameManager.wheatCount < warriorCost)
        {
            warriorNotEnoughWheat.text = "Недостаточно пшеницы";
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
