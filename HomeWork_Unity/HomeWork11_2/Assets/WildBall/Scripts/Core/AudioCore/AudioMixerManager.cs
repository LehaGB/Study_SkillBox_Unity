using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    public string volumeParametr = "MasterVolume";

    private const float MULTIPLIER = 20f;

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(HandleSliderVolumeChanged);
    }

    private void HandleSliderVolumeChanged(float value)
    {
        float volumeValue = (float)Math.Log10(value) * MULTIPLIER;
        audioMixer.SetFloat(volumeParametr, volumeValue);
    }

    void OnDestroy()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(HandleSliderVolumeChanged);
        }
    }
}
