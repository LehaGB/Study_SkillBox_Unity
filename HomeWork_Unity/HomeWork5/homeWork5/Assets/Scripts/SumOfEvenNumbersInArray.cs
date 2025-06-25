using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SumOfEvenNumbersInArray : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    /// <summary>
    /// Метод обработки события OnClick кнопки "Сумма четных чисел в заданном массиве"
    /// </summary>
    public void OnSumEvenNumbersInArray()
    {
        int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        int want = 214;
        int got = SumEvenNumbersInArray(array);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        text.text = ($"Сумма четных чисел в заданном массиве: {got} - {message}");
    }

    /// <summary>
    /// Метод вычисляет сумму четных чисел в массиве 
    /// </summary>
    /// <param name="array">Исходный массив чисел</param>
    /// <returns>Сумма чисел четных чисел</returns>
    private int SumEvenNumbersInArray(int[] array)
    {
        int res = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i] % 2 != 0)
            {
                continue;
            }
            else
            {
                res = res + array[i];
            }
        }
        return res;
    }
}
