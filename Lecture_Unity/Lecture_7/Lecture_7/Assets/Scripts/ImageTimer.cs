using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float maxTime;

    private Image img;
    private float _currenTime;
    private bool _isIncreasing = false; // ����, ������������, ������������� �� ������
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
            // ��������� ������
            _currenTime -= Time.deltaTime;

            if (_currenTime <= 0)
            {
                _currenTime = 0; // ����������, ��� �������� �� ������ � �����
                _isIncreasing = true; // �������� ����������� ������
            }
        }
        else
        {
            // ����������� ������
            _currenTime += Time.deltaTime;

            if (_currenTime >= maxTime)
            {
                _currenTime = maxTime; // ����������, ��� �������� �� ��������� ��������
                _isIncreasing = false; // �������� ��������� ������
            }
        }

        // ��������� fillAmount �����������
        img.fillAmount = _currenTime / maxTime;
    }

}
