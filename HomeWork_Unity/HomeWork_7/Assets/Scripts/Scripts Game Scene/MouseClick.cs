using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{

    public AudioClip clickSound;
    
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ClickMouse();
    }
    public void ClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
            }
            else
            {
                Debug.LogWarning("Звук клика не назначен!");
            }
        }
    }
}
