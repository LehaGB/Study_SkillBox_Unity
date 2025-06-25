using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SumOfEvenNumbersInRange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;


    /// <summary>
    /// Метод обработки события OnClick кнопки "Сумма четных чисел заданного диапазона"
    /// </summary>
    public void Calcaulate()
    {
        int min = 7;
        int max = 21;
        var want = 98;
        int got = SumEvenNumbersInRange(min, max);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        text.text = ($"Сумма четных чисел в диапазоне от " +
            $"{min} до {max} включительно: {got} - {message}");
    }

    /// <summary>
    /// Метод вычисляет сумму четных чисел в заданноном диапазане 
    /// </summary>
    /// <param name="min">Минимальное значение диапазона</param>
    /// <param name="max">Максимальное значение диапазона</param>
    /// <returns>Сумма чисел четных чисел</returns>
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
