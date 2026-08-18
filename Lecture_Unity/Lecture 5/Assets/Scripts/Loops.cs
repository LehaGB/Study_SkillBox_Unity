using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class Loops : MonoBehaviour
{
    private void Start()
    {
        int[] array = SetArray(100);
        //WriteAray(array);

        BubleSort(array);

        WriteAray(array);
    }
    private int[] SetArray(int length)
    {
        int[] arr = new int[length];
        Random rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            arr[i] = rnd.Next(-100, 101);
        }
        return arr;
    }
    private void WriteAray(int[] arr)
    {
        foreach (var item in arr)
        {
            Debug.Log(item);
        }
    }
    private void BubleSort(int[] arr)
    {
        int temp = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if(arr[j] > arr[j + 1])
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}
