using UnityEngine;
using static Unity.VisualScripting.Member;
using Zenject;

public class AudioManager : ScriptableObject,  IAudioManager
{
    // private AudioSource _audioSource;

    ////private AudioClip backgroundClip;
    ////public AudioClip gameClip;

    //public AudioManager(AudioSource audioSource)
    //{
    //    _audioSource = audioSource;
    //}

    public void PlayMusic(AudioClip backgroundClip, AudioSource source, AudioClip clip = null)
    {
        if (clip == null)
        {
            clip = backgroundClip;
        }
        if (clip != null && source != null && !source.isPlaying)
        {
            source.clip = clip;
            source.Play();
        }
    }

    public void SwitchMusic(AudioClip gameClip, AudioSource source, AudioClip clip = null)
    {
        if (clip == null)
        {
            clip = gameClip;
        }
        if (clip != null && source != null && !source.isPlaying)
        {
            source.clip = clip;
            source.Play();
        }
    }

    public void PauseMusic(AudioSource source)
    {  
        if (source != null)
        {
            Debug.Log("Зашли PauseMusic");
            source.Stop();
            Debug.Log("Стоп музыка audioSource");
        }
    }

    public void ResumeMusic(AudioSource source)
    {
        if (source != null)
        {
            source.Play();
        }
    }

    public void MenuMusic(AudioSource source)
    {
        if(source != null)
        {
            source.Stop();
        }
    }
}

