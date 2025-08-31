using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource _boomGadBoysAudio;
    //private BadGuyController badGuyController;
    private PlayerController playerController;



    public AudioClip gadBoysAudioClip;

    private void Start()
    {
        _boomGadBoysAudio = GetComponent<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
        if(playerController != null)
        {
            playerController.BoomBadGuysAudio += AudioGadBoys;
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log($"{playerController} = null");
        }
    }
    private void OnDestroy()
    {
        if (playerController != null)
        {
            playerController.BoomBadGuysAudio -= AudioGadBoys; 
        }
    }
    public void AudioGadBoys()
    {
        _boomGadBoysAudio.PlayOneShot(gadBoysAudioClip);
    }
}
