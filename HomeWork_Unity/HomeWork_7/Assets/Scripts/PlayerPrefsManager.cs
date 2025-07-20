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
    // Метод для сохранения количества волн врагов.
    public static void SaveEnemyWaves(int waveCount)
    {
        SaveResult(PlayerPrefKey.EnemyWaves, waveCount);
    }
    // Метод для сохранения количества пшеницы.
    public static void SaveWheatCount(int wheatCount)
    {
        SaveResult(PlayerPrefKey.CountWheat, wheatCount);
    }
    // Метод для сохранения количества крестьян.
    public static void SavePeasantCount(int saveCountPeasant)
    {
        SaveResult(PlayerPrefKey.CountPeasant, saveCountPeasant);
    }
    // Метод для сохранения количества воинов.
    public static void SaveWarriorCount(int saveCountWarrior)
    {
        SaveResult(PlayerPrefKey.CountWarrior, saveCountWarrior);
    }
    // Метод для сохранения количества падших воинов.
    public static void SaveFalleWarriorsCount(int saveFalleWarriors)
    {
        SaveResult(PlayerPrefKey.FalleWarriors, saveFalleWarriors);
    }
}
