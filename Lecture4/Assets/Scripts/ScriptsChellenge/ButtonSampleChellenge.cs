using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonSampleChellenge : MonoBehaviour
{

    public TextMeshProUGUI text;
    public TextMeshProUGUI counterText;
    public TMP_InputField inputField;

    private int minRandom = 0;
    private int maxRandom = 101;
    public int numberRandom = 0;
    public int numInputField;
    public int counter;
    private void Start()
    {
        numberRandom = Random.Range(minRandom, maxRandom);
    }
    public void ReadText()
    {
        int n = InputNumber();

        if (n > numberRandom)
        {
            text.text = "Загаданое число меньше";
            ++counter;
            counterText.text = counter.ToString();
        }
        else if (n < numberRandom)
        {
            text.text = "Загаданое число больше";
            ++counter;
            counterText.text = counter.ToString();
        }
        else if(inputField.text == "")
        {
            text.text = "Вы ничего не ввели";
        }
        else
        {
            text.text = "Угадали";
            counterText.text = counter.ToString();
        }
    }
    public int InputNumber()
    {
       return numInputField = int.Parse(inputField.text);
    }
}
