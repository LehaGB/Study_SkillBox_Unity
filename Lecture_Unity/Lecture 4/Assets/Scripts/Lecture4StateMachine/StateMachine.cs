using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateMachine : MonoBehaviour
{
    // Объект канвас.
    [SerializeField] private GameObject _firstScreen;
    [SerializeField] private GameObject _secondScreen;
    [SerializeField] TextMeshProUGUI resultText;

    // Какой именно канвас включен.
    private GameObject _currentScreen;

    private void Start()
    {
        // Включаем первый канвас.
        _firstScreen.SetActive(true);
        _currentScreen = _firstScreen;
    }

    public void ChangeState(GameObject state)
    {
        if (_currentScreen != null)
        {
            // Выключаем текущий канвас.
            _currentScreen.SetActive(false);

            // Вкючаем следующий канвас.
            state.SetActive(true);
            _currentScreen = state;
        }
    }
}
