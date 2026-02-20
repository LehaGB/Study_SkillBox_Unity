using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ButtonManager : MonoBehaviour, IButtonManager
{

    public string gameLevelScene = "GameLevelScene";
    public string mainScene = "MainScene";

    public event Action<int> OnLoadLevel;

    public void LoadScene(int indexScene)
    {
        OnLoadLevel?.Invoke(indexScene);

        SceneManager.LoadScene(indexScene);
    }

    public void LoadLevelButtonClicked(int levelIndex)
    {
        LoadScene(levelIndex);
    }

    public void Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(gameLevelScene);
    }

    public void Back()
    {
        SceneManager.LoadScene(mainScene);
    }
}
