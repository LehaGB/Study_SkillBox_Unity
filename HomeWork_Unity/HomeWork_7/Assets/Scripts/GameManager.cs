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
        if(_raidTimer > 0 && _raidTimer < 15)
        {
            StartCoroutine(CoroutineTimeRed());
        }
        if (_raidTimer <= 0)
        {
            _raidTimer = raidMaxTime;
            if(numberMovesAttack > 0)
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
        if (harvestTimer.tick)
        {
            wheatCount += peasantController.peasantCount * peasantController.wheatPerPeasant;
        }
        if (eatingTimer.tick)
        {
            wheatCount -= warriorComtroller.warriorCount * warriorComtroller.wheatToWarriors;
        }
        UpdateText();
    }
    public void UpdateText()
    {
        resourcesWheatText.text = wheatCount.ToString();
    }
    public void UpdateReaidText()
    {
        raidText.text = $"Враг: {nextRaid}";
    }
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
}
