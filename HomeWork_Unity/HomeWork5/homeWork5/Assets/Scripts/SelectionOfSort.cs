using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SelectionOfSort : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;

    /// <summary>
    /// ����� ��������� ������� OnClick ������ "���������� �������"
    /// </summary>
    public void OnSelectionSort()
    {
        int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        text.text = $"�������� ������: [{string.Join(",", originalArray)}]";

        int[] sortedArray = SelectionSort((int[])originalArray.Clone());
        text1.text = $"��������� ����������: [{string.Join(",", sortedArray)}]";

        int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
        text2.text = (sortedArray.SequenceEqual(expectedArray) ? "��������� ������" : "��������� �� ������");
    }

    /// <summary>
    /// ����� ��������� ������ ������� ������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <returns>��������������� ������</returns>
    private int[] SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int n = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if(array[j] < array[n])
                {
                    n = j;
                }
            }
            int tmp = array[i];
            array[i] = array[n];
            array[n] = tmp;
        }
        return array;
    }
}
