using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonManger : MonoBehaviour, IButtonManager
{
    public GameObject panelLost;

    private void OnEnable()
    {
        if(EventsBus.Instance != null)
        {
            EventsBus.Instance.OnPlayerDied += ButtonActive;
        }
    }

    private void OnDestroy()
    {
        if(EventsBus.Instance != null)
        {
            EventsBus.Instance.OnPlayerDied -= ButtonActive;
        }
    }


    public void ButtonActive()
    {
        panelLost.SetActive(true);
    }
}
