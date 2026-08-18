using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TMP_InputField _inputField;

    private int _value = 0;

    private void Start()
    {
        _value = Random.Range(0, 101);
    }
    public void OnCheckClicked()
    {
        if (_inputField.text.Equals(_value.ToString()))
        {
            _text.text = "Вы угадали!";
        }
        else if(int.Parse(_inputField.text) > _value)
        {
            _text.text = "Загаданое число меньше";
        }
        else if (int.Parse(_inputField.text) < _value)
        {
            _text.text = "Загаданое число больше";
        }
    }
}
