using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using Zenject;

public class UIManager : MonoBehaviour
{
    [Inject] private ILoadLevelScene _loadLevelScene;
    [Inject] private TimeController _timeController;
    [Inject] private UIController _uiController;

    private void Start()
    {

    }

    public void ButtonPlayClicked()
    {
        _loadLevelScene?.Game();
        _uiController?.ButtonSwitchMusicClicked();
    }

    public void ButtonExitClicked()
    {
        _loadLevelScene?.Exit();
    } 
    

    public void ButtonMenuClicked()
    {
        _loadLevelScene?.Menu();
        _uiController?.ButtonPlayMusicClicked();
    }

    public void ButtonBackClicked()
    {
        _loadLevelScene?.Back();
        _uiController?.ButtonSwitchMusicClicked();
    }

    public void ButtonLoadLevelClicked(int indexScene)
    {
        _loadLevelScene?.LoadLevelButtonClicked(indexScene);
    }

    public void ButtonPauseClicked()
    {
        _timeController?.SetPauseOn();
        _uiController?.ButtonPauseMusicClicked();
    }

    public void ButtonResumeClicked()
    {
        _timeController?.SetPauseOff();
        _uiController?.ButtonResumeMusicClicked();
    }
}
