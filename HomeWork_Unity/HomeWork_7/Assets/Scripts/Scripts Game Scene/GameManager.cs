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
    public LoadGameScene LoadScene;
    public SoundController soundController;

    public AudioClip attackClip;

    public GameObject gameVictory;
    public GameObject gameScene;

    public TextMeshProUGUI resourcesWheatText;  // вывод количество пшеницы.
    public TextMeshProUGUI raidText;  // вывод количество атакующих.
    public TextMeshProUGUI numberMovesAttackText;  // вывод количество пустых рейдов.
    public TextMeshProUGUI vuctoryText;

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

    [HideInInspector] public AudioSource audioSource;

    private int _warriorLostMin;  // Минимальные потери воинов.
    private int _warriorLostMax;  // Максимальные потери воинов.
    private float _raidTimer;  // время ожидания набега.
    private int _wheatCountForVictory = 20;
    public bool isPlayStopSound = true;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        isPlayStopSound = true;
        _warriorLostMax = warriorComtroller.AddWarriorCount();
        if (_raidTimer <= 0 && isPlayStopSound)
        {
            _raidTimer = raidMaxTime;
            numberEmptyMovesAttack--;
            if (numberEmptyMovesAttack > 0 && isPlayStopSound)
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
                audioSource.PlayOneShot(attackClip);

                CountNumberFalleWarriors();
                CountNumberOfRaid();
            }
        }
        if (_raidTimer > 0 && numberEmptyMovesAttack == 0 && isPlayStopSound)
        {
            StartCoroutine(CoroutineTimeRed());
            raidTimerImg.color = Color.red;
        }
        if (warriorComtroller.warriorCount < 0)
        {
            audioSource.Pause();
        }
        isPlayStopSound = false;
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
        if (wheatCount >= _wheatCountForVictory)
        {
            soundController._audio.Stop();
            audioSource.Pause();
            Time.timeScale = 0;
            gameScene.SetActive(false);
            gameVictory.SetActive(true);
            vuctoryText.text = $"Победа!!! \n " +
                $"Вы создали {wheatCount} пшеницы";
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
        if (numberEmptyMovesAttack > 0)
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
        yield return new WaitForSeconds(0.5f);
        raidTimerImg.color = Color.red;
    }
}
