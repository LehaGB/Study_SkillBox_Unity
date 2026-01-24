using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WildBall.Inputs;

public class PausePlayGame : MonoBehaviour, IPausePLayReturnToMenu
{
    private PlayerController _playerController;


    [SerializeField] private GameObject _playBt;
    [SerializeField] private GameObject _pauseBt;
    [SerializeField] private GameObject _menuBt;
    [SerializeField] public GameObject _againBt;

    private SoundManager _soundManager;


    private void Start()
    {
        _soundManager = SoundManager.Instance;
        _playerController = GetComponent<PlayerController>(); 
    }


    public void Pause()
    {        
        Debug.Log("Зашел в метод Pause");
        Time.timeScale = 0f;
        _playBt.SetActive(true);
        _pauseBt.SetActive(false);
        _menuBt.SetActive(true);
        if (_soundManager != null)
        {
            _soundManager._audioSource.Stop();
            Debug.Log("Музыка Стоп");
        }
    }
    public void Play()
    {
        Debug.Log("Зашел в метод Play");
        Time.timeScale = 1f;
        _playBt.SetActive(false);
        _pauseBt.SetActive(true);
        _menuBt.SetActive(true);


        if (_soundManager != null)
        {
            _soundManager._audioSource.Play();
            Debug.Log("Музыка Play");
        }
    }

    public void Jump()
    {
        _soundManager.PlayJumpSound();
    }


    public void Again()
    {
        _againBt.SetActive(true);
    }

    public void ReturnToMenu(int indexScene)
    {
        Debug.Log("Зашел в метод ReturnToMenu");

        if (_soundManager != null)
        {

            _soundManager._audioSource.Stop();
            Time.timeScale = 0f;
            Debug.Log("Музыка Стоп ReturnToMenu");          
        }
        if (_playerController != null)
        {
            _playerController.CountCoin = 0;
            Debug.Log("_playerController.CountCoin = 0");
        }

        SceneManager.LoadScene(indexScene, LoadSceneMode.Single);
        Debug.Log("LoadSceneMode.Single = удаляем сцену");
    }
}
