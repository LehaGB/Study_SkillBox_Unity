using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using Zenject;

public class UIManager : MonoBehaviour
{
    [Inject] private ILoadLevelScene _loadLevelScene;


    public void ButtonPlayClicked()
    {
        _loadLevelScene.Play();
    }

    public void ButtonExitClicked()
    {
        _loadLevelScene.Exit();
    } 
    

    public void ButtonMenuClicked()
    {
        _loadLevelScene.Menu();
    }

    public void ButtonBackClicked()
    {
        _loadLevelScene.Back();
    }

    public void ButtonLoadLevelClicked(int indexScene)
    {
        _loadLevelScene.LoadLevelButtonClicked(indexScene);
    }

    public void ButtonPauseClicked()
    {
        _loadLevelScene.Pause();
    }

    public void ButtonResumeClicked()
    {
        _loadLevelScene.Resume();
    }
}
