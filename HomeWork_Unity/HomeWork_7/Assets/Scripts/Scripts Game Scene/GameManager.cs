using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PeasantController peasantController;
    public WarriorComtroller warriorComtroller;
    public GameOverController gameOver;
    public LoadScene LoadScene;
    public SoundController soundController;

    public GameObject gameVictory;
    public GameObject gameScene;

    public TextMeshProUGUI resourcesWheatText;  // вывод количество пшеницы.
    public TextMeshProUGUI raidText;  // вывод количество атакующих.
    public TextMeshProUGUI numberMovesAttackText;  // вывод количество пустых рейдов.

    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public Image raidTimerImg;

    public int wheatCount;  // коичество пшеницы.
    public int numberEmptyMovesAttack = 2;  // количество пустых атак.
    public float raidMaxTime;  // время наступления рейда.
    public int raidIncrease;  // увеличение рейда.
    public int nextRaid;   // следующий рейд.
    public int saveWarriosFalleCount;  // Падшие воины.
    public int numberOfRaid;  // Количество рейдов.

    private int _warriorLostMin;  // Минимальные потери воинов.
    private int _warriorLostMax;  // Максимальные потери воинов.
    private float _raidTimer;  // время ожидания набега.
    private int _wheatCountForVictory = 500;


    private void Start()
    {
        UpdateText();
        UpdateReaidText();
        NumbersMovesAttackUpdateText();
        _raidTimer = raidMaxTime;
    }


    private void Update()
    {
        RaidTimer();
    }
    

    // Количество пшеницы.
    public void UpdateText()
    {
        resourcesWheatText.text = $"{wheatCount}";
    }


    // Количество врагов.
    public void UpdateReaidText()
    {
        raidText.text = $"Враг: {nextRaid}";
    }


    // Кол-во ходов до атаки.
    public void NumbersMovesAttackUpdateText()
    {
        numberMovesAttackText.text = $"Ход до атаки: {numberEmptyMovesAttack}";
    }


    /// <summary>
    ///  Ататка врагов.
    /// </summary>
    public void EnemyAttack()
    {
        _warriorLostMax = warriorComtroller.AddWarriorCount();
        if (_raidTimer <= 0)
        {
            _raidTimer = raidMaxTime;
            numberEmptyMovesAttack--;

            if (numberEmptyMovesAttack > 0)
            {
                NumbersMovesAttackUpdateText();
            }
            else
            {
                numberMovesAttackText.text = "Наступление врагов";
               
                _warriorLostMin = Mathf.Min(warriorComtroller.warriorCount, nextRaid);
                Mathf.Abs(warriorComtroller.warriorCount -= nextRaid);


                if (_warriorLostMin > 0)
                {
                    saveWarriosFalleCount += _warriorLostMin;
                    _warriorLostMax -= saveWarriosFalleCount;
                }
                nextRaid += raidIncrease;
                CountNumberFalleWarriors();
                CountNumberOfRaid();
            }
        }
        if (_raidTimer > 0 && _raidTimer < 15 && numberEmptyMovesAttack == 0)
        {
            StartCoroutine(CoroutineTimeRed());
        }
        UpdateReaidText();
    }


    // Таймер атаки.
    public void RaidTimer()
    {
        _raidTimer -= Time.deltaTime;
        raidTimerImg.fillAmount = _raidTimer / raidMaxTime;

        if (harvestTimer.tick)
        {
            if (wheatCount > 0)
            {
                wheatCount += peasantController.peasantCount * peasantController.wheatPerPeasant;
            }
            else
            {
                wheatCount = 0;
                wheatCount += peasantController.wheatPerPeasant;
            }
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
        if (wheatCount == _wheatCountForVictory)
        {
            soundController._audio.Stop();
            Time.timeScale = 0;
            gameScene.SetActive(false);
            gameVictory.SetActive(true);
        }
        CountNumberWheat();
        UpdateText();
        EnemyAttack();
    }


    // Сохраняем количество набегов.
    public void CountNumberOfRaid()
    {
        numberOfRaid++;
    }


    // Количество набегов для GameOver.
    public int ReturnCountNumberOfRaid()
    {
        if(numberEmptyMovesAttack > 0)
        {
            numberOfRaid = 0;
        }
        else
        {
            --numberOfRaid;
        }
        return numberOfRaid;
    }


    // Количество пшеницы для GameOver.
    public int CountNumberWheat()
    {
        return wheatCount;
    }


    // Падшие воины для GameOver.
    public int CountNumberFalleWarriors()
    {
        return saveWarriosFalleCount;
    }


    // Убитые враги.
    public int CountSlainEnemies()
    {
        nextRaid = saveWarriosFalleCount;
        return nextRaid;
    }
    

    // Выжившие воины.
    public int NumberSurvivingWarriors()
    {
        return _warriorLostMax;
    }


    // Меняю цвет часов, при атаке.
    IEnumerator CoroutineTimeRed()
    {
        yield return new WaitForSeconds(3);
        raidTimerImg.color = Color.red;
    }
}
