using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalController : MonoBehaviour
{
    public ParticleSystem _particleSystem;


    private void OnEnable()
    {
        EventsBus.Instance.OnCoinDestroy += IsActiveParticalCoinDestroy;
    }

    private void OnDestroy()
    {
        EventsBus.Instance.OnCoinDestroy -= IsActiveParticalCoinDestroy;
    }
    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }

    public void IsActiveParticalCoinDestroy()
    {
        _particleSystem.Play();
    }
}

  

