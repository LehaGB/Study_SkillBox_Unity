using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();
                if( _instance == null)
                {
                    GameObject soundmanagerGo = new GameObject("SoundManager");
                    _instance = soundmanagerGo.AddComponent<SoundManager>();
                }
            }
            return _instance;
        }
    }

    public AudioSource _audioSource;
    public bool _isActiveSound = true;

    public AudioClip coinClip;
    public AudioClip jumpClip;
    public AudioClip victoryClip;

    private void Awake()
    {
        
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
    }
    private void Start()
    {
        
        if( coinClip != null )
        {
            coinClip.LoadAudioData();
        }
        if(jumpClip != null )
        {
            jumpClip.LoadAudioData();
        }
        if( victoryClip != null)
        {
            victoryClip.LoadAudioData();
        }   
    }


    // Монетка.
    public void PlayCoinSound()
    {
        if(_isActiveSound && coinClip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(coinClip);
        }      
    }


    // Прыжок.
    public void PlayJumpSound()
    {
        if(_isActiveSound && jumpClip != null && _audioSource != null && _audioSource.enabled)
        {
            _audioSource.PlayOneShot(jumpClip);
        }   
    }

    // Победа.
    public void PlayVictoryClip()
    {
        if (_isActiveSound && victoryClip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(victoryClip);
        }
    }
}
