using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePlayGame : MonoBehaviour, IPausePLayReturnToMenu
{
    public LoadLevelSceneManager scene;
    private PlayerController _playerController;

    [SerializeField] private GameObject _playBt;
    [SerializeField] private GameObject _pauseBt;
    [SerializeField] private GameObject _menuBt;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = SoundManager.Instance;
        _playerController = GetComponent<PlayerController>();
    }
    public void Pause()
    {
        Debug.Log("Зашел в метод Pause");
        if (_pauseBt != null)
        {
            Debug.Log(" в if");
           // Time.timeScale = 0f;
            _playBt.SetActive(true);
            _pauseBt.SetActive(true);
            _menuBt.SetActive(true);
            _soundManager._audioSource.Stop();
        }      
    }
    public void Play()
    {
        if (_playBt != null && _pauseBt != null)
        {
            Debug.Log("Зашел в метод Play");
            //Time.timeScale = 1f;
            _playBt.SetActive(true);
            _pauseBt.SetActive(true);
            _menuBt.SetActive(true);
            _soundManager._audioSource.Play();
        }
    }
    public void ReturnToMenu(int indexScene)
    {
        if(_playerController != null)
        {
            _playerController.CountCoin = 0;
            Destroy(_playerController.gameObject);
        }
        SceneManager.LoadScene(indexScene, LoadSceneMode.Single);
    }
}
