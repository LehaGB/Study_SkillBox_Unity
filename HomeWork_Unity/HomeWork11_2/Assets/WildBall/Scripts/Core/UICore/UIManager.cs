using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   //private IAudioManager _audioManager = new AudioManager();

    [Header("Managers")]  
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private TimerController timerController;

    private CreatePreyer _createPreyer;

    private AudioSource _uiAudioSource;    
    private bool _isPausedActive;

    [Header("Canvas")]
    public GameObject canvasGamePause;
    public GameObject canvasMain;
    public GameObject canvasSettings;


    //[Header("Clips")]
    //public AudioClip backgroundClip;
    //public AudioClip gameClip;
    //private AudioClip clip = null;

    public bool IsPausedActive { get { return _isPausedActive; } set { _isPausedActive = value; } }

    void Start()
    {
        _uiAudioSource = GetComponent<AudioSource>();
        _createPreyer = FindAnyObjectByType<CreatePreyer>();
    }

    public void ButtonPlayClicked(string nameScene)
    {
        if (!IsPausedActive)
        {
            IsPausedActive = false;
            
            timerController?.SetPauseOff();
        }
        _createPreyer.CreatePlayerPrefab();
        sceneLoader?.LoadNameScene(nameScene);
        //_audioManager?.SwitchMusic(gameClip, _uiAudioSource, clip);
    }


    public void ButtonPauseClicked(bool isPaused = true)
    {
        IsPausedActive = isPaused;
        if (IsPausedActive)
        {                    
            //_audioManager?.PauseMusic(_uiAudioSource);
            timerController?.SetPauseOn();
            canvasSettings.SetActive(true);
        }
        else if(!IsPausedActive)
        {
            //_audioManager?.ResumeMusic(_uiAudioSource);
            timerController?.SetPauseOff();
            canvasSettings.SetActive(false);
        }
        IsPausedActive = false;
    }

    public void ButtonExitClicked()
    {
        sceneLoader?.QuitGame();
    }

    public void LoadSceneButtonClicked(int indexScene)
    {

        if (IsPausedActive)
        {
            IsPausedActive = false;
            timerController?.SetPauseOff();
            sceneLoader?.LoadLevelButtonClicked(indexScene);
        }
        
        //_audioManager?.SwitchMusic(gameClip, _uiAudioSource, clip);
    }

    public void ToggCanvasLevel()
    {
        IsPausedActive = !IsPausedActive;
        canvasGamePause.SetActive(!IsPausedActive);
        canvasGamePause.SetActive(IsPausedActive);
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
