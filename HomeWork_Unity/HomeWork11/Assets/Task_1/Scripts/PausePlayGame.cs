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


    public void Pause()
    {
        if (playBt != null && pauseBt != null && menuBt != null)
        {
            Time.timeScale = 0f;
            playBt.SetActive(true);
            pauseBt.SetActive(false);
            menuBt.SetActive(true);
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
        }
    }
    public void ReturnToMenu(int indexScene)
    {
        _scene.LoadScene(indexScene);
    }
}
