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
    [Inject] private AudioManager _audioManager;

    public void ButtonPlayClicked()
    {
        _loadLevelScene?.Play();
        _audioManager?.SwitchMusic();
    }

    public void ButtonExitClicked()
    {
        _loadLevelScene?.Exit();
    } 
    

    public void ButtonMenuClicked()
    {
        _loadLevelScene?.Menu();
        _audioManager?.PlayMusic();
    }

    public void ButtonBackClicked()
    {
        _loadLevelScene?.Back();
        _audioManager?.SwitchMusic();
    }

    public void ButtonLoadLevelClicked(int indexScene)
    {
        _loadLevelScene?.LoadLevelButtonClicked(indexScene);
    }

    public void ButtonPauseClicked()
    {
        _timeController?.SetPauseOn();
        _audioManager?.PauseMusic();
    }

    public void ButtonResumeClicked()
    {
        _timeController?.SetPauseOff();
        _audioManager?.ResumeMusic();
    }
}
