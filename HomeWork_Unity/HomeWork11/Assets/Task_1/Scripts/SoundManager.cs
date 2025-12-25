using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource m_audioSource;
    
    public AudioClip coinClip;
    public AudioClip jumpClip;
    public bool isActiveSound = true;


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        if (m_audioSource == null)
        {
            m_audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayCoinSound()
    {
        if(isActiveSound && coinClip != null && m_audioSource != null)
        {
            m_audioSource.PlayOneShot(coinClip);
        }
        
    }


    public void PlayJumpSound()
    {
        if(isActiveSound && jumpClip != null && m_audioSource != null)
        {
            m_audioSource?.PlayOneShot(jumpClip);
        }   
    }
}
