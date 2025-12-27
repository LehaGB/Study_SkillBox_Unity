using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlayGame : MonoBehaviour, IPausePLayReturnToMenu
{
    public LoadLevelSceneManager _scene;


    [SerializeField] private GameObject playBt;
    [SerializeField] private GameObject pauseBt;
    [SerializeField] private GameObject menuBt;

    private SoundManager m_soundManager;

    private void Start()
    {
        m_soundManager = SoundManager.Instance;
    }
    public void Pause()
    {
        if (playBt != null && pauseBt != null && menuBt != null)
        {
            Time.timeScale = 0f;
            playBt.SetActive(true);
            pauseBt.SetActive(false);
            menuBt.SetActive(true);
            m_soundManager.m_audioSource.Pause();
        }      
    }
    public void Play()
    {
        if (playBt != null && pauseBt != null)
        {
            Time.timeScale = 1f;
            playBt.SetActive(false);
            pauseBt.SetActive(true);
            menuBt.SetActive(false);
            m_soundManager.m_audioSource.Play();
        }
    }
    public void ReturnToMenu(int indexScene)
    {
        _scene.LoadScene(indexScene);
    }
}
