using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private AudioManager _iAudioManager;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private TimerController _timerController;
    [SerializeField] private GameManager _gameManager;

    private AudioSource _uiAudioSource;    
    private bool _isPausedActive;

    [Header("Canvas")]
    public GameObject canvasLevel;
    public GameObject canvasMain;
    public GameObject canvasSettings;

    [Header("Clips")]
    public AudioClip backgroundClip;
    public AudioClip gameClip;
    private AudioClip clip = null;

    public bool IsPausedActive { get { return _isPausedActive; } set { _isPausedActive = value; } }

    void Start()
    {
        _uiAudioSource = GetComponent<AudioSource>();
    }

    public void ButtonPlayClicked(string nameScene)
    {
        if (!IsPausedActive)
        {
            IsPausedActive = false;
            
            _timerController?.SetPauseOff();
        }
        _gameManager.CreatePlayerPrefab();
        _sceneLoader?.LoadNameScene(nameScene);
        _iAudioManager?.SwitchMusic(gameClip, _uiAudioSource, clip);
    }


    public void ButtonPauseClicked(bool isPaused = true)
    {
        IsPausedActive = isPaused;
        if (IsPausedActive)
        {                    
            _iAudioManager?.PauseMusic(_uiAudioSource);
            _timerController?.SetPauseOn();
            canvasLevel.SetActive(true);
        }
        else if(!IsPausedActive)
        {
            _iAudioManager?.ResumeMusic(_uiAudioSource);
            _timerController?.SetPauseOff();
            canvasLevel.SetActive(false);
        }
        IsPausedActive = false;
    }

    public void ButtonExitClicked()
    {
        _sceneLoader?.QuitGame();
    }

    public void LoadSceneButtonClicked(int indexScene)
    {

        if (!IsPausedActive)
        {
            IsPausedActive = false;
            _timerController?.SetPauseOff();
            _sceneLoader?.LoadLevelButtonClicked(indexScene);
        }
        
        _iAudioManager?.SwitchMusic(gameClip, _uiAudioSource, clip);
    }

    public void ToggCanvasLevel()
    {
        IsPausedActive = !IsPausedActive;
        canvasLevel.SetActive(IsPausedActive);
        canvasLevel.SetActive(!IsPausedActive);
    }
    public void ToggCanvasMain()
    {
        IsPausedActive = !IsPausedActive;
        canvasMain.SetActive(IsPausedActive);
        canvasMain.SetActive(!IsPausedActive);
    }

    public void ToggCanvasSettings()
    {
        IsPausedActive = !IsPausedActive;
        canvasSettings.SetActive(IsPausedActive);
        canvasMain.SetActive(!IsPausedActive);
    }
}
