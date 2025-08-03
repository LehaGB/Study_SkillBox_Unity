using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public SoundController soundController;
    public WarriorComtroller warriorComtroller;
    public PeasantController peasantController;

    public Button pausePlayButton;
    public Button soundButton;
    public Sprite pauseSprite;
    public Sprite playSprite;

    private Image _pausePlayButtonImage;
    public bool _isPaused =  false;

    private void Start()
    {
        _pausePlayButtonImage = pausePlayButton.GetComponent<Image>();
    }

    public void PauseGame()
    {
        if (soundController == null) return;
        if (_isPaused)
        {
            Time.timeScale = 1;
            _pausePlayButtonImage.sprite = playSprite;
            soundController._audio.Play();
            soundButton.interactable = true;
            warriorComtroller.warriorButton.interactable = true;
            peasantController.peasantButton.interactable = true;         
        }
        else
        {
            Time.timeScale = 0;
            _pausePlayButtonImage.sprite = pauseSprite;
            soundController._audio.Pause();
            soundButton.interactable = false;
            warriorComtroller.warriorButton.interactable = false;
            peasantController.peasantButton.interactable = false;
        }
        _isPaused = !_isPaused;
    }
}
