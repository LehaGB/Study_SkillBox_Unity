using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PeasantController peasantController;
    public WarriorComtroller warriorComtroller;

    public TextMeshProUGUI resourcesWheatText;  // количество пшеницы.
    public TextMeshProUGUI raidText;  // количество атакующих.
    public TextMeshProUGUI numberMovesAttackText;  // количество пустых рейдов.

    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public Image raidTimerImg;


    public int wheatCount;  // коичество пшеницы.
    public int numberMovesAttack = 1;
    public float raidMaxTime;  // время наступления рейда.
    public int raidIncrease;  // увеличение рейда.
    public int nextRaid;   // следующий рейд.

    public int newWheatCount;
    private float _raidTimer;  // время ожидания набега.

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

    // Количество пшеницы.
    public void UpdateText()
    {
        resourcesWheatText.text = wheatCount.ToString();
    }

    // Количество врагов.
    public void UpdateReaidText()
    {
        raidText.text = $"Враг: {nextRaid}";
    }

    // Кол-во ходов до атаки.
    public void NumbersMovesAttack()
    {
        numberMovesAttackText.text = $"Ход до атаки: {numberMovesAttack--}";
    }
    IEnumerator CoroutineTimeRed()
    {
        raidTimerImg.color = Color.red;
        yield return new WaitForSeconds(3);
        raidTimerImg.color = new Color(250, 250, 250, 250);
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
            if (numberMovesAttack > 0)
            {
                numberMovesAttackText.text = $"Ход до атаки: {numberMovesAttack--}";

                UpdateReaidText();
            }
            else
            {
                warriorComtroller.warriorCount -= nextRaid;
                nextRaid += raidIncrease;
                numberMovesAttackText.text = "Наступление врагов";
            }
            UpdateReaidText();
        }
    }
}
