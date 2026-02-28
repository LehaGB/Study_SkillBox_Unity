using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : IButtonManager
{
    private IButtonManager _iButtonManager;
    public ButtonManager(IButtonManager iButtonManager)
    {
        _iButtonManager = iButtonManager;
    }
    public event Action<int> OnLoadLevel;

    public void LoadScene(int indexScene)
    {
        OnLoadLevel?.Invoke(indexScene);

        SceneManager.LoadScene(indexScene, LoadSceneMode.Single);
    }

    public void LoadLevelButtonClicked(int levelIndex)
    {
        LoadScene(levelIndex);
    }

    public void Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void Exit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void Menu(string gameLevelScene)
    {
        SceneManager.LoadScene(gameLevelScene, LoadSceneMode.Single);
    }

    public void Back(string mainScene)
    {
        SceneManager.LoadScene(mainScene, LoadSceneMode.Single);
    }
}
