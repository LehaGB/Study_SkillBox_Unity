using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsTester : MonoBehaviour
{
    private float _fuel = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < 3f)
        {
            _fuel -= 0.01f * Time.deltaTime; 
        }
        else
        {
            Debug.Log("Fuel" + _fuel);
        }
    }
}
