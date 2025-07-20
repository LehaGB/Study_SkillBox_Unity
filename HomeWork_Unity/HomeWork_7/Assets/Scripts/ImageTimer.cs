using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float maxTime;
    public bool tick;

    private Image img;
    private float _currenTime;

    


    void Start()
    {
        img = GetComponent<Image>();
        _currenTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {

        tick = false;

        // Уменьшаем таймер
        _currenTime -= Time.deltaTime;

        if (_currenTime <= 0)
        {
            tick = true;
            _currenTime = maxTime;
        }
        img.fillAmount = _currenTime / maxTime;
    }
    public void ResetTimer()
    {
        _currenTime = maxTime;
        tick = false;
    }
}
