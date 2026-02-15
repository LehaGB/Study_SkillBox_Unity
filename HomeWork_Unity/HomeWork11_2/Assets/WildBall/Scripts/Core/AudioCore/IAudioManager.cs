using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IAudioManager 
{
    void PlayMusic(AudioClip backgroundClip, AudioSource source, AudioClip clip = null);
    void SwitchMusic(AudioClip gameClip, AudioSource source, AudioClip clip = null);
    void PauseMusic(AudioSource source);
    void ResumeMusic(AudioSource source);

    void MenuMusic(AudioSource source);
}
