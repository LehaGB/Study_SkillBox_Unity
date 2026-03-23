using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    private IUICanvasManager _canvasManager = new CanvasManager();

    [Header("Managers")]  
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private TimerController _timerController;
    [SerializeField] private AudioMixerManager _mixerManager;

    private CreatePreyer _createPreyer;

    //private AudioSource _uiAudioSource;    
    private bool _isPausedActive;

    [Header("Canvas")]
    //public GameObject canvasGamePause;
    public GameObject canvasMain;
    public GameObject canvasSettings;
    public GameObject canvasLevel;

    public bool IsPausedActive { get { return _isPausedActive; } set { _isPausedActive = value; } }

    void Start()
    {
        //_uiAudioSource = GetComponent<AudioSource>();
        _createPreyer = FindAnyObjectByType<CreatePreyer>();
    }

    public void ButtonPlayClicked(string nameScene)
    {
        if (!IsPausedActive)
        {
            IsPausedActive = false;
            
            _timerController?.SetPauseOff();
        }
        _createPreyer.CreatePlayerPrefab();
        _sceneLoader?.LoadNameScene(nameScene);
    }


    public void ButtonPauseClicked()
    {
        _canvasManager.ToggCanvasSettings(canvasSettings, true);
        _timerController.SetPauseOn();
    }

    public void ButtonMenuCkicked()
    {
        _canvasManager.ToggCanvasLevel(canvasLevel, true);
    }


    public void ButtonSettingCkicked()
    {
        _canvasManager.ToggCanvasSettings(canvasSettings, true);
    }


    public void ButtonBackClicked()
    {
        _canvasManager.ToggButtonBack(canvasMain, true);
    }

    public void ButtonExitClicked()
    {
        _sceneLoader?.QuitGame();
    }

    public void LoadSceneButtonClicked(int indexScene)
    {

        if (IsPausedActive)
        {
            IsPausedActive = false;
            _timerController?.SetPauseOff();
        }
        _sceneLoader?.LoadLevelButtonClicked(indexScene);
    }
}
