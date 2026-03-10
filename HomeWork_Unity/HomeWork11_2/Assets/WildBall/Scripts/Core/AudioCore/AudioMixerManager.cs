using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioMixerManager : MonoBehaviour
{
    [Header("AudioMixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Sliders")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider jumpSlider;
    [SerializeField] private Slider gameSlider;

    [Header("Parametrs")]
    public string volumeParametr = "Volume";
    public string jumpParametr = "JumpVolume";
    public string gameParametr = "GameVolume";

    private const float MULTIPLIER = 20f;

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(HandleSliderVolumeChanged);
        jumpSlider.onValueChanged.AddListener(HandleSliderJumpChanged);
        gameSlider.onValueChanged.AddListener(HandleSliderGameChanged);
    }

    public void HandleSliderVolumeChanged(float value)
    {
        float volumeValue = (float)Math.Log10(value) * MULTIPLIER;
        audioMixer.SetFloat(volumeParametr, volumeValue);
    }


    public void HandleSliderJumpChanged(float value)
    {
        float jumpValue = (float)Math.Log10(value) * MULTIPLIER;
        audioMixer.SetFloat(jumpParametr, jumpValue);
    }

    public void HandleSliderGameChanged(float value)
    {
        float gameValue = (float)Math.Log10(value) * MULTIPLIER;
        audioMixer.SetFloat(gameParametr, gameValue);
    }
}
