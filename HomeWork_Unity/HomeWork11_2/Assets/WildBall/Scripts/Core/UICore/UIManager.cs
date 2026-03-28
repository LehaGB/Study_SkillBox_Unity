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
    private bool _isPausedActive;

    [Header("Canvas")]
    public GameObject canvasMain;
    public GameObject canvasSettings;
    public GameObject canvasLevel;

    public bool IsPausedActive { get { return _isPausedActive; } set { _isPausedActive = value; } }


    void Start()
    {
        _createPreyer = FindAnyObjectByType<CreatePreyer>();
        _mixerManager = FindAnyObjectByType<AudioMixerManager>();
    }


    // Pplay.
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


    // Pause.
    public void ButtonPauseClicked()
    {
        _canvasManager.ToggCanvasSettings(canvasSettings, true);
        _timerController.SetPauseOn();
    }


    public void ButtonResumeClicked()
    {
        _canvasManager.ToggCanvasSettings(canvasSettings, false);
        _timerController.SetPauseOff();
    }


    // Level.
    public void ButtonLevelCkicked()
    {
        _canvasManager.ToggCanvasLevel(canvasLevel, true);
        _canvasManager.ToggCanvasMain(canvasMain, false);
    }


    // Settings.
    public void ButtonSettingCkicked()
    {
        _canvasManager.ToggCanvasSettings(canvasSettings, true);
        _canvasManager.ToggCanvasMain(canvasMain, false);
    }


    // Back.
    public void ButtonBackClicked()
    {
        _canvasManager.ToggButtonBack(canvasMain, true);
        _canvasManager.ToggCanvasMain(canvasSettings, false);
    }


    // Exit.
    public void ButtonExitClicked()
    {
        _sceneLoader?.QuitGame();
    }


    // Load Scene.
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
