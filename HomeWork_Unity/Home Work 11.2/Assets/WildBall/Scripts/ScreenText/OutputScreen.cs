using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OutputScreen : MonoBehaviour
{
    public TextMeshProUGUI textE;
    public TextMeshProUGUI textLevel;
    public string text = "E";

    public void ScreenText()
    {
        textE.gameObject.SetActive(true);
        textE.text = text;
    }

    public void ScreenExitText()
    {
        textE.gameObject.SetActive(false);
    }
}
