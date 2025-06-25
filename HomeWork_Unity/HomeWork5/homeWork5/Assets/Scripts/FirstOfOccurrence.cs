using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstOfOccurrence : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text1;

    /// <summary>
    /// ����� ��������� ������� OnClick ������ "����� ������� ��������� ����� � ������"
    /// </summary>
    public void OnFirstOccurrence()
    {
        // ������ ����, ����� ����������� � �������
        int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        int value = 34;
        int want = 3;
        int got = FirstOccurrence(array, value);
        string message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        text.text = ($"����� ������� ��������� {value} � ������: {got} - {message}");

        // ������ ����, ����� �� ����������� � �������
        array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        value = 55;
        want = -1;
        got = FirstOccurrence(array, value);
        message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        text1.text = ($"������ ������� ��������� ����� {value} � ������: {got} - {message}");
    }


    /// <summary>
    /// ����� ���������� ����� ������� ��������� ����� � ������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <param name="value">������� �����</param>
    /// <returns>������ �������� ����� � ������� ��� -1 ���� ����� ����������</returns>
    private int FirstOccurrence(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }
        return -1;
    }
}
