using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{

    public PauseController pauseController;

    public Button soundButton;      // Ссылка на компонент Button.

    public Sprite soundOnSprite;    // Спрайт для состояния "Звук включен".
    public Sprite soundOffSprite;   // Спрайт для состояния "Звук выключен".

    private Image buttonImage;       // Ссылка на компонент Image кнопки.

    public bool isSoundOn = true;

    [HideInInspector] public AudioSource _audio;


    // Получем компонет.
    private void Start()
    {
        buttonImage = soundButton.GetComponent<Image>();
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }


    // Аудиопроигрыватель.(меняем спрайт при выключении музыки).
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
