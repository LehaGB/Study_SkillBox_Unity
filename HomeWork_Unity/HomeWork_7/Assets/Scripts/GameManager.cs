using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PeasantController peasantController;
    public WarriorComtroller warriorComtroller;
    //public PlayerPrefsManager playerPrefs;

    public TextMeshProUGUI resourcesWheatText;  // количество пшеницы.
    public TextMeshProUGUI raidText;  // количество атакующих.
    public TextMeshProUGUI numberMovesAttackText;  // количество пустых рейдов.

    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public Image raidTimerImg;


    public int wheatCount;  // коичество пшеницы.
    public int numberEmptyMovesAttack = 2;  // количество пустых атак.
    public float raidMaxTime;  // время наступления рейда.
    public int raidIncrease;  // увеличение рейда.
    public int nextRaid;   // следующий рейд.
    public int numberOfRaid = 0;  // количество набегов.

    public int newWheatCount;  // Всео изготовленно пшеницы.
    private float _raidTimer;  // время ожидания набега.
    private int saveWarriosFalleCount = 0;  // Падшие воины.

    private void Start()
    {
        UpdateText();
        UpdateReaidText();
        NumbersMovesAttackUpdateText();
        _raidTimer = raidMaxTime;
    }

    private void Update()
    {
        //peasantController.IsNotEnoughWheatTimer();
        //warriorComtroller.IsNotEnoughWheatTimer();
        _raidTimer -= Time.deltaTime;
        raidTimerImg.fillAmount = _raidTimer / raidMaxTime;
        
        if (harvestTimer.tick)
        {
            if(wheatCount > 0)
            {
                wheatCount += peasantController.peasantCount * peasantController.wheatPerPeasant;
            }
            else
            {
                wheatCount += peasantController.wheatPerPeasant;         
            }
            newWheatCount = wheatCount;
            PlayerPrefsManager.SaveWheatCount(newWheatCount);
            harvestTimer.ResetTimer();
        }
        if (eatingTimer.tick)
        {
            if (wheatCount > 0)
            {
                wheatCount -= warriorComtroller.warriorCount * warriorComtroller.wheatToWarriors;
            }
            eatingTimer.ResetTimer();
        }
        UpdateText();
        EnemyAttack();
    }

    // Количество пшеницы.
    public void UpdateText()
    {
        resourcesWheatText.text = $"{Mathf.Round(wheatCount)}";
    }

    // Количество врагов.
    public void UpdateReaidText()
    {
        raidText.text = $"Враг: {nextRaid}";
    }

    // Кол-во ходов до атаки.
    public void NumbersMovesAttackUpdateText()
    {
        numberMovesAttackText.text = $"Ход до атаки: {numberEmptyMovesAttack--}";
    }
    IEnumerator CoroutineTimeRed()
    {
        raidTimerImg.color = Color.red;
        yield return new WaitForSeconds(3);
    }

    /// <summary>
    ///  Ататка врагов.
    /// </summary>
    public void EnemyAttack()
    {
        if (_raidTimer > 0 && _raidTimer < 15)
        {
            StartCoroutine(CoroutineTimeRed());
        }
        if (_raidTimer <= 0)
        {
            _raidTimer = raidMaxTime;

            if (numberEmptyMovesAttack > 0)
            {
                NumbersMovesAttackUpdateText();
            }
            else
            {
                numberMovesAttackText.text = "Наступление врагов";
                warriorComtroller.warriorCount -= nextRaid;
                saveWarriosFalleCount = Mathf.Abs(warriorComtroller.warriorCount);
                nextRaid += raidIncrease;
                PlayerPrefsManager.SaveFalleWarriorsCount(saveWarriosFalleCount);
                GameOver();
            }
        }
        
        UpdateReaidText();
    }

    // Сохраняем количество набегов в PlayerPrefs
    public void GameOver()
    { 
        PlayerPrefsManager.SaveEnemyWaves(numberOfRaid - 1);
        numberOfRaid++;
    }
}
