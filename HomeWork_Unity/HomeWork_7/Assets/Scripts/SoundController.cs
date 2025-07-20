using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Button soundButton;      // ������ �� ��������� Button.

    //public AudioClip audioGameOverClip;

    public Sprite soundOnSprite;    // ������ ��� ��������� "���� �������".
    public Sprite soundOffSprite;   // ������ ��� ��������� "���� ��������".
    private Image buttonImage;       // ������ �� ��������� Image ������.

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
        if (_audio.isPlaying)
        {
            _audio.Pause();
            buttonImage.sprite = soundOffSprite;
        }
        else
        {
            _audio.Play();
            buttonImage.sprite = soundOnSprite;
        }
    }
}
