using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticalController : MonoBehaviour
{
    public ParticleSystem exposion;

    private void Awake()
    {
        exposion = GetComponent<ParticleSystem>();
        exposion.Stop();
    }


    private void OnEnable()
    {
        if(EventsBus.Instance != null)
        {
            EventsBus.Instance.OnCoinDestroy += IsActiveExplosion;        
        }
    }


    private void OnDestroy()
    {
        if (EventsBus.Instance != null)
        {
            EventsBus.Instance.OnCoinDestroy -= IsActiveExplosion;           
        }
    }

    public void IsActiveExplosion()
    {
        if (exposion != null)
        {
            exposion.Play();
        }
    }
}

  

