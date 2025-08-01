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

    public TextMeshProUGUI resourcesWheatText;  // ����� ���������� �������.
    public TextMeshProUGUI raidText;  // ����� ���������� ���������.
    public TextMeshProUGUI numberMovesAttackText;  // ����� ���������� ������ ������.
    public TextMeshProUGUI vuctoryText;

    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public Image raidTimerImg;

    public int wheatCount;  // ��������� �������.
    public int numberEmptyMovesAttack = 2;  // ���������� ������ ����.
    public float raidMaxTime;  // ����� ����������� �����.
    public int raidIncrease;  // ���������� �����.
    public int nextRaid;   // ��������� ����.
    public int saveWarriosFalleCount;  // ������ �����.
    public int numberOfRaid;  // ���������� ������.

    [HideInInspector] public AudioSource audioSource;

    private int _warriorLostMin;  // ����������� ������ ������.
    private int _warriorLostMax;  // ������������ ������ ������.
    private float _raidTimer;  // ����� �������� ������.
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
    

    // ���������� �������.
    public void UpdateText()
    {
        resourcesWheatText.text = $"{wheatCount}";
    }


    // ���������� ������.
    public void UpdateReaidText()
    {
        raidText.text = $"����: {nextRaid}";
    }


    // ���-�� ����� �� �����.
    public void NumbersMovesAttackUpdateText()
    {
        numberMovesAttackText.text = $"��� �� �����: {numberEmptyMovesAttack}";
    }


    /// <summary>
    ///  ������ ������.
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
                numberMovesAttackText.text = "����������� ������";

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


    // ������ �����.
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
            vuctoryText.text = $"������!!! \n " +
                $"�� ������� {wheatCount} �������";
        }
        CountNumberWheat();
        UpdateText();
        EnemyAttack();
    }


    // ��������� ���������� �������.
    public void CountNumberOfRaid()
    {
        numberOfRaid++;
    }


    // ���������� ������� ��� GameOver.
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


    // ���������� ������� ��� GameOver.
    public int CountNumberWheat()
    {
        return wheatCount;
    }


    // ������ ����� ��� GameOver.
    public int CountNumberFalleWarriors()
    {
        return saveWarriosFalleCount;
    }


    // ������ �����.
    public int CountSlainEnemies()
    {
        nextRaid = saveWarriosFalleCount;
        return nextRaid;
    }


    // �������� �����.
    public int NumberSurvivingWarriors()
    {
        return _warriorLostMax;
    }


    // ����� ���� �����, ��� �����.
    IEnumerator CoroutineTimeRed()
    {
        yield return new WaitForSeconds(0.5f);
        raidTimerImg.color = Color.red;
    }
}
