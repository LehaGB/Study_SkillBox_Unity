using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCanvas : MonoBehaviour
{
    public string nameSceneToLoad;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void SoundMainScene()
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
