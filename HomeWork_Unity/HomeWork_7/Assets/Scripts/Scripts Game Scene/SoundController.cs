using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{

    public PauseController pauseController;

    public Button soundButton;      // ������ �� ��������� Button.

    public Sprite soundOnSprite;    // ������ ��� ��������� "���� �������".
    public Sprite soundOffSprite;   // ������ ��� ��������� "���� ��������".

    private Image buttonImage;       // ������ �� ��������� Image ������.

    public bool isSoundOn = true;

    [HideInInspector] public AudioSource _audio;


    // ������� ��������.
    private void Start()
    {
        buttonImage = soundButton.GetComponent<Image>();
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }


    // ������������������.(������ ������ ��� ���������� ������).
    public void ChangeSoundPlayPause()
    {
        if (_audio.isPlaying && isSoundOn)
        {
            _audio.Pause();
            buttonImage.sprite = soundOffSprite;
        }
        else
        {
            _audio.Play();
            buttonImage.sprite = soundOnSprite;
        }
        isSoundOn = !isSoundOn;
    }
}
