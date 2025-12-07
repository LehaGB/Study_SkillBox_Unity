using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelSceneManager : MonoBehaviour, ILoadLevelScene
{
    public event Action <int> OnLoadLevel;

    public void LoadScene(int indexScene)
    {
        OnLoadLevel?.Invoke(indexScene);

        SceneManager.LoadScene(indexScene);
    }


    // Вызываем LoadScene с индексом уровня
    public void LoadLevelButtonClicked(int levelIndex)
    {
        LoadScene(levelIndex); 
    }
}
