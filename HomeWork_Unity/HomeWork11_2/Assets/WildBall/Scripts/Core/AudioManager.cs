using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private static AudioManager _Instance;

    public AudioClip backgroundClip;
    public AudioClip gameClip;

    public static AudioManager Instance
    {
        get 
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<AudioManager>();
                if (_Instance == null)
                {
                    GameObject gameObject = new GameObject("AudioManager");
                    _Instance = gameObject.AddComponent<AudioManager>();                    
                }
            }
            return _Instance;
        }       
    }

    private void Awake()
    {
        if(_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _audioSource = GetComponent<AudioSource>();
        if(_audioSource == null)
        {
            _audioSource.loop = true;
        }
        //_Instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic(AudioClip clip = null)
    {
        if(clip == null)
        {
            clip = backgroundClip;
        }
        if(clip != null && _audioSource != null && !_audioSource.isPlaying)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    public void SwitchMusic(AudioClip clip = null)
    {
        if(clip == null)
        {
            clip = gameClip;            
        }
        if (clip != null && _audioSource != null && !_audioSource.isPlaying)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    public void PauseMusic()
    {
        if(_audioSource != null && _audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }

    public void ResumeMusic()
    {
        if (_audioSource != null && _audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
}

