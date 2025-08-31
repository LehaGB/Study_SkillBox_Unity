using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyController : MonoBehaviour
{

    public event Action BoomBadGuysAudio;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SuperMan"))
        {
            BoomBadGuysAudio?.Invoke();
        }
    }
}
