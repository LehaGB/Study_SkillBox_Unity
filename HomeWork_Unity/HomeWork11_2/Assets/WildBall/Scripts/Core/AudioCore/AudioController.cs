using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioController : MonoBehaviour
{
    [Inject] private IAudioManager _iAudioManager;
    [Inject] private IButtonManager _loadLevelScene;
    [Inject] private TimeController _timeController;

    private AudioSource _uiAudioSource;
    private AudioClip clip = null;

    public AudioClip backgroundClip;
    public AudioClip gameClip;

    void Start()
    {
        _uiAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPlayMusicClicked()
    {
        _iAudioManager?.PlayMusic(backgroundClip, _uiAudioSource, clip);
    }


    public void ButtonSwitchMusicClicked()
    {
        _iAudioManager?.SwitchMusic(gameClip, _uiAudioSource, clip);
    }

    public void ButtonPauseMusicClicked()
    {
        _iAudioManager?.PauseMusic(_uiAudioSource);
    }

    public void ButtonResumeMusicClicked()
    {
        _iAudioManager?.ResumeMusic(_uiAudioSource);
    }

    public void ButtonMenuMusicClicked()
    {
        _iAudioManager?.MenuMusic(_uiAudioSource);
    }
}
