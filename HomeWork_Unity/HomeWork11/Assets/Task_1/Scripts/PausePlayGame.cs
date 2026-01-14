using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePlayGame : MonoBehaviour, IPausePLayReturnToMenu
{
    public LoadLevelSceneManager scene;
    private PlayerController playerController;

    [SerializeField] private GameObject m_playBt;
    [SerializeField] private GameObject m_pauseBt;
    [SerializeField] private GameObject m_menuBt;

    private SoundManager m_soundManager;

    private void Start()
    {
        m_soundManager = SoundManager.Instance;
    }
    public void Pause()
    {
        if (m_playBt != null && m_pauseBt != null && m_menuBt != null)
        {
            Time.timeScale = 0f;
            m_playBt.SetActive(true);
            m_pauseBt.SetActive(true);
            m_menuBt.SetActive(true);
        }      
    }
    public void Play()
    {
        if (m_playBt != null && m_pauseBt != null)
        {
            Time.timeScale = 1f;
            m_playBt.SetActive(true);
            m_pauseBt.SetActive(true);
            m_menuBt.SetActive(true);
        }
    }
    public void ReturnToMenu(int indexScene)
    {
        if(playerController != null)
        {
            playerController.CountCoin = 0;
            Destroy(playerController.gameObject);
        }
        SceneManager.LoadScene(indexScene, LoadSceneMode.Single);
    }
}
