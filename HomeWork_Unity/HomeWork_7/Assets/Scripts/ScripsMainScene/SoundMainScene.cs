using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMainScene : MonoBehaviour
{
    public string nameSceneToLoad;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void SoundMainScenes()
    {
        if(_audioSource != null && string.IsNullOrEmpty(nameSceneToLoad))
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
