using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private AudioSource _audioSource;

    public GameObject superMan;
    public Vector3 offset;

   
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void LateUpdate()
    {
        transform.position = superMan.transform.position + offset;
    }

    public void StopMusic()
    {
        if(_audioSource != null)
        {
            _audioSource.Stop();
        }
    }
}
