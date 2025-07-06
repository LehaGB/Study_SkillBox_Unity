using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float maxTime;

    private Image img;
    private float _currenTime;
    private bool _isIncreasing = false; // Флаг, показывающий, увеличивается ли таймер
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        _currenTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isIncreasing)
        {
            // Уменьшаем таймер
            _currenTime -= Time.deltaTime;

            if (_currenTime <= 0)
            {
                _currenTime = 0; // Убеждаемся, что значение не уходит в минус
                _isIncreasing = true; // Начинаем увеличивать таймер
            }
        }
        else
        {
            // Увеличиваем таймер
            _currenTime += Time.deltaTime;

            if (_currenTime >= maxTime)
            {
                _currenTime = maxTime; // Убеждаемся, что значение не превышает максимум
                _isIncreasing = false; // Начинаем уменьшать таймер
            }
        }

        // Обновляем fillAmount изображения
        img.fillAmount = _currenTime / maxTime;
    }

}
