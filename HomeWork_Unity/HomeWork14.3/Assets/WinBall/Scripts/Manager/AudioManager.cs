using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource backgrounMusicSource;
    [SerializeField] private AudioSource jumpMusicSource;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Sounds")]
    [SerializeField] private AudioData[] sounds;

    private Dictionary<SoundType, AudioClip> clips;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        clips = new Dictionary<SoundType, AudioClip>();

        foreach(var sound in sounds)
        {
            clips[sound.sound] = sound.clip;
        }
    }
    

    public void PlayCoin(SoundType sound)
    {
        if (!clips.TryGetValue(sound, out var clip)) 
        {
            Debug.LogError($"Не найден звук {sound}");
            return;
        } 

        sfxSource.PlayOneShot(clip);
    }


    public void PlayJump(SoundType sound)
    {
        if (!clips.TryGetValue(sound, out var clip))
        {
            Debug.LogError($"Не найден звук {sound}");
            return;
        }

        jumpMusicSource.PlayOneShot(clip);
    }

    public void PlayMusic(SoundType sound)
    {
        if (!clips.TryGetValue(sound, out var clip)) return;

        backgrounMusicSource.clip = clip;
        backgrounMusicSource.loop = true;
        backgrounMusicSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    public void SetJumpVolume(float volume)
    {
        audioMixer.SetFloat("JumpVolume", Mathf.Log10(volume) * 20);
    }
}
