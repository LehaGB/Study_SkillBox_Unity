using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SumOfEvenNumbersInRange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;


    /// <summary>
    /// ����� ��������� ������� OnClick ������ "����� ������ ����� ��������� ���������"
    /// </summary>
    public void Calcaulate()
    {
        int min = 7;
        int max = 21;
        var want = 98;
        int got = SumEvenNumbersInRange(min, max);
        string message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        text.text = ($"����� ������ ����� � ��������� �� " +
            $"{min} �� {max} ������������: {got} - {message}");
    }

    /// <summary>
    /// ����� ��������� ����� ������ ����� � ���������� ��������� 
    /// </summary>
    /// <param name="min">����������� �������� ���������</param>
    /// <param name="max">������������ �������� ���������</param>
    /// <returns>����� ����� ������ �����</returns>
    private int SumEvenNumbersInRange(int min, int max)
    {
        int res = 0;
        for (int i = min; i <= max; i++)
        {
            if (i % 2 != 0)
            {
                continue;
            }
            else
            {
                res = res + i;
            }
        }
        return res;
    }
}
