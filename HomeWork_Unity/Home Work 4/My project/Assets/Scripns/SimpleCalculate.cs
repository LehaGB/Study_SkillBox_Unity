using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCalculate : MonoBehaviour
{
    [SerializeField] private GameObject _firstScreen;
    [SerializeField] private GameObject _calculateScreen;
    [SerializeField] private GameObject _comparisonScreen;

    private GameObject _currentScreen;

    private void Start()
    {
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
