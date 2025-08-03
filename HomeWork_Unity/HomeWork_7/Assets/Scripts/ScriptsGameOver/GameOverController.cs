using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button resultButton;
    public GameManager gameManager;
    public WarriorComtroller warriorComtroller;
    public PeasantController peasantController;

    public TextMeshProUGUI raidCountText;
    public TextMeshProUGUI wheatCountText;
    public TextMeshProUGUI peasantCountText;
    public TextMeshProUGUI warriorsCountText;
    public TextMeshProUGUI warriorsFalleCountText;

    private int _wheatCount;
    private int _peasantCount;
    private int _warriorsCount;
    private int _warriorsFalleCount;
    private int _numberOfRaid;

    public void ResultGameOver()
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
    }
}
    

