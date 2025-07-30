using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public AudioClip wheatClip;

    public float maxTime;
    public bool tick;

    private AudioSource _audioSource;
    private float _currenTime;
    private bool _soundPlay =  false;

    [HideInInspector]public Image img;
    


    


    void Start()
    {
        img = GetComponent<Image>();
        _audioSource = gameObject.AddComponent<AudioSource>();
        _currenTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {

        tick = false;

        // Уменьшаем таймер
        _currenTime -= Time.deltaTime;

        if (_currenTime <= 0 && !_soundPlay)
        {
            tick = true;
            _currenTime = maxTime;
            _audioSource.PlayOneShot(wheatClip);
            _soundPlay = true;
        }
        img.fillAmount = _currenTime / maxTime;

        if(_currenTime > 0)
        {
            _soundPlay = false;
        }
    }
    public void ResetTimer()
    {
        _currenTime = maxTime;
        tick = false;
        _soundPlay = false;
    }
}
