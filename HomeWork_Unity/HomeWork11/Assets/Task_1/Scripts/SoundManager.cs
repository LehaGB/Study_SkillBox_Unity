using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource _audioSource;
    public bool _isActiveSound = true;

    public AudioClip coinClip;
    public AudioClip jumpClip;
    public AudioClip victoryClip;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        _audioSource.enabled = true;
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

    public void PlayCoinSound()
    {
        if(_isActiveSound && coinClip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(coinClip);
        }
        
    }


    public void PlayJumpSound()
    {
        if(_isActiveSound && jumpClip != null && _audioSource != null && _audioSource.enabled)
        {
            _audioSource.PlayOneShot(jumpClip);
        }   
    }


    public void PlayVictoryClip()
    {
        if (_isActiveSound && victoryClip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(victoryClip);
        }
    }
}
