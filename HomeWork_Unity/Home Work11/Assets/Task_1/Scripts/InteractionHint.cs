using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionHint : MonoBehaviour
{
    private SoundManager _soundManager;
    private BuildIndexScene _indexScene;
    
    public TextMeshProUGUI hintTextUI;
    public GameObject player;

    public string hintText = "ֽאזלטעו ֵ";

    private bool _isZone = false;
    private int _indexLevel;


    private void Awake()
    {
        _soundManager = SoundManager.Instance;
        _indexScene = GetComponent<BuildIndexScene>();
    }

    private void Start()
    {

        if (hintTextUI == null)
        {
            enabled = false;
            return;
        }
        if(player  == null)
        {
            enabled = false;
            return;
        }
        hintTextUI.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (_isZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _indexScene.LoadBuildIndexScene();
                _soundManager._audioSource.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isZone = true;
            ShowHit();            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _isZone = false;
            HideHint();
        }
    }

    private void HideHint()
    {
        hintTextUI.gameObject.SetActive(false);
    }

    private void ShowHit()
    {
        hintTextUI.text = hintText;
        hintTextUI.gameObject.SetActive(true);
        SoundManager.Instance.PlayVictoryClip();
    }
}
