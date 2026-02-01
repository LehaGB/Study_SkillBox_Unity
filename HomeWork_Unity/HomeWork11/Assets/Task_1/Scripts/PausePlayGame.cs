using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WildBall.Inputs;

public class PausePlayGame : MonoBehaviour
{
    private FactoryButtonManager _buttonManager = new ButtonManager();

    private PlayerController _playerController;

    [SerializeField] private GameObject _playBt;
    [SerializeField] private GameObject _pauseBt;
    [SerializeField] private GameObject _menuBt;
    [SerializeField] private GameObject _againBt;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = SoundManager.Instance;
    }


    public void ButtonPause()
    {        
        Debug.Log("Зашел в метод Pause");

        _buttonManager.Pause(_pauseBt, _playBt);

        if (_soundManager != null)
        {
            _soundManager._audioSource.Stop();
            Debug.Log("Музыка Стоп");
        }
    }
    public void ButtonPlay()
    {
        Debug.Log("Зашел в метод Play");
        
        _buttonManager.Play(_playBt, _pauseBt);

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

    
    public void ButtonAgain()
    {
        _buttonManager.Again(_againBt);
    }

    public void ButtonReturnToMenu(int indexScene)
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

        _buttonManager.ReturnToMenu(indexScene);
        Debug.Log("LoadSceneMode.Single = удаляем сцену");
    }
}
