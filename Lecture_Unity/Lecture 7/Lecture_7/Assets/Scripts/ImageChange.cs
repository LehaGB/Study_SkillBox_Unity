using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Sprite newSprite;
    public List<AudioClip> newClip;

    private Image img;
    private AudioSource _audio;


    void Start()
    {
        img = GetComponent<Image>();
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Меняем спрайт.
    public void ChangeSprite()
    {
        img.sprite = newSprite;
        img.SetNativeSize();
    }


    // Меняем на спрайте цвет.
    public void ChahgeColor()
    {
        //img.color = Color.magenta;
        img.color = new Color(0.1f, 0.2f, 0.3f);
    }
    public void ChangeAudioPlayPause()
    {
        if (_audio.isPlaying)
        {
            _audio.Pause();
        }
        else
        {
            _audio.Play();
        }
    }
    public void ChangeSound()
    {
        if(newClip.Count > 0)
        {
            int randomIndexClip = Random.Range(0, newClip.Count);
            _audio.clip = newClip[randomIndexClip];
            _audio.Play();
        }
        else
        {
            Debug.Log("Клипов нет");
        }
    }
}
