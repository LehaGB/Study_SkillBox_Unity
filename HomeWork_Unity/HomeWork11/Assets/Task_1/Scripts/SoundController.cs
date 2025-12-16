using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource m_audioSource;

    public AudioClip coinClip;
    public bool isActiveSound = true;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&& isActiveSound)
        {
            m_audioSource.PlayOneShot(coinClip);
            Destroy(gameObject, coinClip.length);
        }
    }
}
