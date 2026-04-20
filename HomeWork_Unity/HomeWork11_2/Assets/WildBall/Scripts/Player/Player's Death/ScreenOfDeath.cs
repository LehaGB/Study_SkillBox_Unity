using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOfDeath : MonoBehaviour, IScreenDeath
{
    [SerializeField] private GameObject _canvasLost;
    private void OnEnable()
    {
        if (EventsBus.Instance != null)
        {
            //EventsBus.Instance.OnPlayerDied += DeactivationCanvas;
            EventsBus.Instance.OnPlayerDied += PanelActive;
        }

    }

    private void OnDestroy()
    {
        if (EventsBus.Instance != null)
        {
            //EventsBus.Instance.OnPlayerDied -= DeactivationCanvas;
            EventsBus.Instance.OnPlayerDied -= PanelActive;
        }
    }

    public void PanelActive()
    {
        _canvasLost.SetActive(true);
    }
}
