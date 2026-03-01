using UnityEngine;

public class AudioManager : MonoBehaviour
{

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
            source.Pause();
            Debug.Log("Стоп музыка audioSource");
        }
    }

    public void ResumeMusic(AudioSource source)
    {
        Debug.Log("Зашли ResumeMusic");
        if (source != null)
        {
            source.UnPause();
        }
        Debug.Log("Play музыка audioSource");
    }

    public void MenuMusic(AudioSource source)
    {
        Debug.Log("Зашли MenuMusic");
        if (source != null)
        {
            source.Stop();
        }
        Debug.Log("Зашли в главное меню");
    }
}

