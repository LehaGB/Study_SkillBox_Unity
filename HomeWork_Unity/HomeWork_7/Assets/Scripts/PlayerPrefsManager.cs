using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public enum PlayerPrefKey
    {
        EnemyWaves,
        CountWheat,
        CountPeasant,
        CountWarrior,
        FalleWarriors
    }
    public static void SaveResult(PlayerPrefKey key, int value)
    {
        PlayerPrefs.SetInt(key.ToString(), value);
        PlayerPrefs.Save();
    }
    public static int GetInt(PlayerPrefKey key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key.ToString(), defaultValue);
    }
    // ����� ��� ���������� ���������� ���� ������.
    public static void SaveEnemyWaves(int waveCount)
    {
        SaveResult(PlayerPrefKey.EnemyWaves, waveCount);
    }
    // ����� ��� ���������� ���������� �������.
    public static void SaveWheatCount(int wheatCount)
    {
        SaveResult(PlayerPrefKey.CountWheat, wheatCount);
    }
    // ����� ��� ���������� ���������� ��������.
    public static void SavePeasantCount(int saveCountPeasant)
    {
        SaveResult(PlayerPrefKey.CountPeasant, saveCountPeasant);
    }
    // ����� ��� ���������� ���������� ������.
    public static void SaveWarriorCount(int saveCountWarrior)
    {
        SaveResult(PlayerPrefKey.CountWarrior, saveCountWarrior);
    }
    // ����� ��� ���������� ���������� ������ ������.
    public static void SaveFalleWarriorsCount(int saveFalleWarriors)
    {
        SaveResult(PlayerPrefKey.FalleWarriors, saveFalleWarriors);
    }
}
