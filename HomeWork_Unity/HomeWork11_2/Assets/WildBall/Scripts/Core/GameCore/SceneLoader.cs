using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
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

    public void LoadNameScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
