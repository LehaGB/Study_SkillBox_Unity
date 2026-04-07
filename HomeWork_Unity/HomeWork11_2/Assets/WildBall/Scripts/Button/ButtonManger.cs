using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonManger : MonoBehaviour, IButtonManager
{
    public GameObject button;

    public void ButtonActive()
    {
        button.SetActive(true);
    }
}
