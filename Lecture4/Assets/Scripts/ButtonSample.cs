using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSample : MonoBehaviour
{
    public Text couter;
    public InputField inputField;
    int a = 0;

    private void Start()
    {
        couter.text = "0";
    }
    public void OnPress()
    {
        ++a;
        couter.text = (a).ToString();
    }
    public void ReadText()
    {
        if(inputField.text == "")
        {
            couter.text = "Enter the text!";
        }
        else
        {
            couter.text = inputField.text;
        }
    }
}
