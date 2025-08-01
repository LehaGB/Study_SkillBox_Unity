using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickMainScene : MonoBehaviour
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

    void Update()
    {
        ClickMouse();
    }


    // Нажали на кнопку мышки.
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
