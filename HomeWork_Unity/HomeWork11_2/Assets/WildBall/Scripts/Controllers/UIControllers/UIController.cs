using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private IAudioManager _iAudioManager;
    private static IButtonManager _buttonManager;
    private TimerController _timerController;

    private AudioSource _uiAudioSource;
    private AudioClip clip = null;
    private bool _isPausedActive;

    public GameObject canvasLevel;
    public GameObject canvasMain;
    public GameObject canvasSettings;
    public AudioClip backgroundClip;
    public AudioClip gameClip;

    public bool IsPausedActive { get { return _isPausedActive; } set { _isPausedActive = value; } }

    void Start()
    {
        _uiAudioSource = GetComponent<AudioSource>();
        
    }

    public void ButtonPlayClicked()
    {
        _buttonManager?.Game();
        _iAudioManager?.SwitchMusic(gameClip, _uiAudioSource, clip);
    }


    public void ButtonPauseClicked(bool isPaused = true)
    {
        IsPausedActive = isPaused;
        if (IsPausedActive)
        {         
            _iAudioManager?.ResumeMusic(_uiAudioSource);
            _timerController?.SetPauseOff();
        }
        else
        {
            _iAudioManager?.PauseMusic(_uiAudioSource);
            _timerController?.SetPauseOn();
        }
        IsPausedActive = false;
    }

    public void ButtonExitClicked()
    {
        _buttonManager?.Exit();
    }

    public void LoadSceneButtonClicked(int indexScene)
    {
        _buttonManager?.LoadLevelButtonClicked(indexScene);
        _iAudioManager?.SwitchMusic(gameClip, _uiAudioSource, clip);
    }

    public void ButtonMenuClicked(string nameScene)
    {
        if (!IsPausedActive)
        {
            IsPausedActive = false;
            _timerController?.SetPauseOff();
        }
        _buttonManager?.Back(nameScene);
        _iAudioManager?.SwitchMusic(backgroundClip, _uiAudioSource, clip);
    }

    public void ButtonBackClicked()
    {
        ToggCanvas();
    }


    public void ToggCanvas()
    {
        IsPausedActive = !IsPausedActive;
        canvasLevel.SetActive(IsPausedActive);
        canvasMain.SetActive(!IsPausedActive);
    }

    public void ToggCanvasSettings()
    {
        IsPausedActive = !IsPausedActive;
        canvasSettings.SetActive(IsPausedActive);
        canvasMain.SetActive(!IsPausedActive);
    }
}
