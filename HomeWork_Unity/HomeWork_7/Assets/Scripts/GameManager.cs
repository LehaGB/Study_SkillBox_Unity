using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PeasantController peasantController;
    public WarriorComtroller warriorComtroller;

    public TextMeshProUGUI resourcesWheatText;  // ���������� �������.
    public TextMeshProUGUI raidText;  // ���������� ���������.
    public TextMeshProUGUI numberMovesAttackText;  // ���������� ������ ������.

    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public Image raidTimerImg;


    public int wheatCount;  // ��������� �������.
    public int numberMovesAttack = 1;
    public float raidMaxTime;  // ����� ����������� �����.
    public int raidIncrease;  // ���������� �����.
    public int nextRaid;   // ��������� ����.

    public int newWheatCount;
    private float _raidTimer;  // ����� �������� ������.

    private void Start()
    {
        UpdateText();
        UpdateReaidText();
        NumbersMovesAttack();
        _raidTimer = raidMaxTime;
    }

    private void Update()
    {
        peasantController.CreatePeasantTime();
        warriorComtroller.CreateWarriorTime();
        _raidTimer -= Time.deltaTime;
        raidTimerImg.fillAmount = _raidTimer / raidMaxTime;
        EnemyAttack();


        if (harvestTimer.tick)
        {
            if(wheatCount > 0)
            {
                wheatCount += peasantController.peasantCount * peasantController.wheatPerPeasant;
                eatingTimer.ResetTimer();
            }
        }
        if (eatingTimer.tick)
        {
            if(wheatCount > 0)
            {
                wheatCount -= warriorComtroller.warriorCount * warriorComtroller.wheatToWarriors;
                eatingTimer.ResetTimer();
            }
        }
        UpdateText();
    }

    // ���������� �������.
    public void UpdateText()
    {
        resourcesWheatText.text = wheatCount.ToString();
    }

    // ���������� ������.
    public void UpdateReaidText()
    {
        raidText.text = $"����: {nextRaid}";
    }

    // ���-�� ����� �� �����.
    public void NumbersMovesAttack()
    {
        numberMovesAttackText.text = $"��� �� �����: {numberMovesAttack--}";
    }
    IEnumerator CoroutineTimeRed()
    {
        raidTimerImg.color = Color.red;
        yield return new WaitForSeconds(3);
        raidTimerImg.color = new Color(250, 250, 250, 250);
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
            if (numberMovesAttack > 0)
            {
                numberMovesAttackText.text = $"��� �� �����: {numberMovesAttack--}";

                UpdateReaidText();
            }
            else
            {
                warriorComtroller.warriorCount -= nextRaid;
                nextRaid += raidIncrease;
                numberMovesAttackText.text = "����������� ������";
            }
            UpdateReaidText();
        }
    }
}
