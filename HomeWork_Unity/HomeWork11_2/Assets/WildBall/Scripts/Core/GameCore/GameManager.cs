using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Managers")]
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TimerController timerController;


    private void Awake()
    {
        if (sceneLoader == null) sceneLoader = FindObjectOfType<SceneLoader>();
        if (audioManager == null) audioManager = FindObjectOfType<AudioManager>();
        if (uiManager == null) uiManager = FindObjectOfType<UIManager>();
        if (timerController == null) timerController = FindObjectOfType<TimerController>();

        DontDestroyOnLoad(this); 
        DontDestroyOnLoad(sceneLoader);
        DontDestroyOnLoad(audioManager);
    }
}
