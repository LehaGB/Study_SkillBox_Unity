using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoeyGameController : MonoBehaviour
{
    public Button resultVictoryButton;

    public GameManager gameManager;
    public WarriorComtroller warriorComtroller;
    public PeasantController peasantController;

    public TextMeshProUGUI raidCountText;
    public TextMeshProUGUI wheatCountText;
    public TextMeshProUGUI peasantCountText;
    public TextMeshProUGUI warriorsCountText;
    public TextMeshProUGUI warriorsFalleCountText;
    public TextMeshProUGUI survivingWarriorsText;
    public TextMeshProUGUI slainEnemiesText;
    

    private int _wheatCount;
    private int _peasantCount;
    private int _warriorsCount;
    private int _warriorsFalleCount;
    private int _numberOfRaid;
    private int _numberSurvivorsWarriors;
    private int _numberSlainEnemies;
    private int _survivingWarriors;

    public void ResultGameVictory()
    {
        _numberOfRaid = gameManager.ReturnCountNumberOfRaid();
        raidCountText.text = $"Набеги врагов: {_numberOfRaid}";

        _wheatCount = gameManager.CountNumberWheat();
        wheatCountText.text = $"Количество пшеницы: {_wheatCount}";

        _peasantCount = peasantController.AddPeasantCount();
        peasantCountText.text = $"Количество крестьян: {_peasantCount}";

        _warriorsCount = warriorComtroller.IncrementWarriorCount();
        warriorsCountText.text = $"Количество воинов: {_warriorsCount}";

        _warriorsFalleCount = gameManager.CountNumberFalleWarriors();
        warriorsFalleCountText.text = $"Падшие воины: {_warriorsFalleCount}";

        _survivingWarriors = gameManager.NumberSurvivingWarriors();
        survivingWarriorsText.text = $"Выжившие воины: {Mathf.Abs(_survivingWarriors)}";

        _numberSlainEnemies = gameManager.CountSlainEnemies();
        slainEnemiesText.text = $"Убитые враги: {_numberSlainEnemies}";
    }
}
