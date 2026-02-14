using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using Zenject;

public class UIManager : MonoBehaviour
{
    [Inject] private ILoadLevelScene _loadLevelScene;

    [SerializeField] private GameObject _panelButtonPlay;
    [SerializeField] private GameObject _panelButtonExit;


    private int _indexScene;

#if UNITY_EDITOR
    private void OnValidate()
    {
        _panelButtonPlay = transform.Find("PanelButtonPlay").gameObject;
        _panelButtonExit = transform.Find("PanelButtonPlay").gameObject;
    }
#endif


    public void ButtonPlayClicked()
    {
        _loadLevelScene.Play();
    }

    public void ButtonExitClicked()
    {
        _loadLevelScene.Exit();
    } 
    
    public void LoadLevel()
    {
        _loadLevelScene.LoadLevelButtonClicked(_indexScene);
    }
}
