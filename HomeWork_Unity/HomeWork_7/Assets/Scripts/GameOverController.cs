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

    private int _numberOfEnemyRaid = 0;  // ���������� �������.
    private int _wheatCount = 0;  // ������� �������.
    private int _peasantCount = 0;  // ������� ��������
    private int _warriorsCount = 0;  // ������� ������.
    private int _warriorsFalleCount = 0;  // ������ �����.
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
            raidCountText.text = $"������ ������: {_numberOfEnemyRaid}\n";
        }
        if(wheatCountText.text != null)
        {
            wheatCountText.text = $"���������� �������: {_wheatCount}";
        }
        if(peasantCountText.text != null)
        {
            peasantCountText.text = $"���������� ��������: {_peasantCount}";
        }
        if (warriorsCountText.text != null)
        {
            warriorsCountText.text = $"���������� ������: {_warriorsCount}";
        }
        if(warriorsFalleCountText.text != null)
        {
            warriorsFalleCountText.text = $"������ �����: {_warriorsFalleCount}";
        }
    }
}
