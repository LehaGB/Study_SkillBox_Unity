using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputScreen : MonoBehaviour
{
    public TextMeshProUGUI destroyBadGuyText;

    private List<GoodBoysController> _goodBoysControllers = new List<GoodBoysController>();
    private int _countDestroyBadGuy = 0;
    private int _lastDisplayedCount = -1;

    // Start is called before the first frame update
    void Start()
    {
        GoodBoysController[] controllers = FindObjectsOfType<GoodBoysController>();
        _goodBoysControllers.AddRange(controllers);
        foreach (var controller in _goodBoysControllers)
        {
            controller.OnEnemyDestroyed += UpdateTotalCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText(); 
    }

    private void UpdateText()
    {
        if(destroyBadGuyText != null && _countDestroyBadGuy != _lastDisplayedCount)
        {
            destroyBadGuyText.text = $"Враги: { _countDestroyBadGuy}";
            _lastDisplayedCount = _countDestroyBadGuy;
        }
    }

    public void UpdateTotalCount()
    {
        _countDestroyBadGuy = 0;
        foreach (GoodBoysController controller in _goodBoysControllers)
        {
            _countDestroyBadGuy += controller.CountBadGuy;
        }
    }
}
