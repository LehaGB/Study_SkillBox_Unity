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

    public TextMeshProUGUI resourcesWheatText;  // ���������� �������.
    public TextMeshProUGUI raidText;  // ���������� ���������.
    public TextMeshProUGUI numberMovesAttackText;  // ���������� ������ ������.

    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public Image raidTimerImg;


    public int wheatCount;  // ��������� �������.
    public int numberEmptyMovesAttack = 2;  // ���������� ������ ����.
    public float raidMaxTime;  // ����� ����������� �����.
    public int raidIncrease;  // ���������� �����.
    public int nextRaid;   // ��������� ����.
    public int numberOfRaid = 0;  // ���������� �������.

    public int newWheatCount;  // ���� ������������ �������.
    private float _raidTimer;  // ����� �������� ������.
    private int saveWarriosFalleCount = 0;  // ������ �����.

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

    // ���������� �������.
    public void UpdateText()
    {
        resourcesWheatText.text = $"{Mathf.Round(wheatCount)}";
    }

    // ���������� ������.
    public void UpdateReaidText()
    {
        raidText.text = $"����: {nextRaid}";
    }

    // ���-�� ����� �� �����.
    public void NumbersMovesAttackUpdateText()
    {
        numberMovesAttackText.text = $"��� �� �����: {numberEmptyMovesAttack--}";
    }
    IEnumerator CoroutineTimeRed()
    {
        raidTimerImg.color = Color.red;
        yield return new WaitForSeconds(3);
    }

    /// <summary>
    ///  ������ ������.
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
                numberMovesAttackText.text = "����������� ������";
                warriorComtroller.warriorCount -= nextRaid;
                saveWarriosFalleCount = Mathf.Abs(warriorComtroller.warriorCount);
                nextRaid += raidIncrease;
                PlayerPrefsManager.SaveFalleWarriorsCount(saveWarriosFalleCount);
                GameOver();
            }
        }
        
        UpdateReaidText();
    }

    // ��������� ���������� ������� � PlayerPrefs
    public void GameOver()
    { 
        PlayerPrefsManager.SaveEnemyWaves(numberOfRaid - 1);
        numberOfRaid++;
    }
}
