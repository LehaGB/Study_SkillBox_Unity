using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlayGame : PlayPauseReturnToMenuManager
{
    public LoadLevelSceneManager _scene;


    [SerializeField] private GameObject playBt;
    [SerializeField] private GameObject pauseBt;
    [SerializeField] private GameObject menuBt;


    public override void Pause()
    {
        if (playBt != null && pauseBt != null && menuBt != null)
        {
            Time.timeScale = 0f;
            playBt.SetActive(true);
            pauseBt.SetActive(false);
            menuBt.SetActive(true);
        }      
    }
    public override void Play()
    {
        if (playBt != null && pauseBt != null)
        {
            Time.timeScale = 1f;
            playBt.SetActive(false);
            pauseBt.SetActive(true);
            menuBt.SetActive(false);
        }
    }
    public override void ReturnToMenu(int indexScene)
    {
        _scene.LoadScene(indexScene);
    }
}
