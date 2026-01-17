using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorutineSample : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            Debug.Log($"{i}");
        }  
    }  
}
