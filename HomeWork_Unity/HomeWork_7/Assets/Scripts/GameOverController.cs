using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button resultButton;

    public TextMeshProUGUI raidCountText;
    public TextMeshProUGUI wheatCountText;
    public TextMeshProUGUI peasantCountText;
    public TextMeshProUGUI warriorsCountText;
    public TextMeshProUGUI warriorsFalleCountText;

    private int _numberOfEnemyRaid = 0;  // Количество набегов.
    private int _wheatCount = 0;  // Создано пшеницы.
    private int _peasantCount = 0;  // Создано крестьян
    private int _warriorsCount = 0;  // Создано воинов.
    private int _warriorsFalleCount = 0;  // Падшие воины.
    //int saveEnemyWaves = 0;

    private void Start()
    {
        _numberOfEnemyRaid = PlayerPrefsManager.GetInt(PlayerPrefsManager.PlayerPrefKey.EnemyWaves, 0);
        _wheatCount = PlayerPrefsManager.GetInt(PlayerPrefsManager.PlayerPrefKey.CountWheat, 0);
        _peasantCount = PlayerPrefsManager.GetInt(PlayerPrefsManager.PlayerPrefKey.CountPeasant, 0);
        _warriorsCount = PlayerPrefsManager.GetInt(PlayerPrefsManager.PlayerPrefKey.CountWarrior, 0);
        _warriorsFalleCount = PlayerPrefsManager.GetInt(PlayerPrefsManager.PlayerPrefKey.FalleWarriors, 0);
    }

    public void ResultGameOver()
    {
        if (raidCountText.text != null)
        {
            raidCountText.text = $"Набеги врагов: {_numberOfEnemyRaid}\n";
        }
        if(wheatCountText.text != null)
        {
            wheatCountText.text = $"Количество пшеницы: {_wheatCount}";
        }
        if(peasantCountText.text != null)
        {
            peasantCountText.text = $"Количество крестьян: {_peasantCount}";
        }
        if (warriorsCountText.text != null)
        {
            warriorsCountText.text = $"Количество воинов: {_warriorsCount}";
        }
        if(warriorsFalleCountText.text != null)
        {
            warriorsFalleCountText.text = $"Падшие воины: {_warriorsFalleCount}";
        }
    }
}
