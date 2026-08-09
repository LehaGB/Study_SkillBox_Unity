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
    [SerializeField] private AudioSource winMusicSource;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Sounds")]
    [SerializeField] private AudioData[] sounds;

    public float MusicVolume { get; private set; } = 1f;
    public float SFXVolume { get; private set; } = 1f;
    public float JumpVolume { get; private set; } = 1f;

    private Dictionary<SoundType, AudioClip> clips;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

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

    public void PlayWin(SoundType sound)
    {
        if (!clips.TryGetValue(sound, out var clip)) return;

        winMusicSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    public void SetJumpVolume(float volume)
    {
        JumpVolume = volume;
        audioMixer.SetFloat("JumpVolume", Mathf.Log10(volume) * 20);
    }
}
