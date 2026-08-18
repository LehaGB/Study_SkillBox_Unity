using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImpulse : MonoBehaviour
{
    public float impulseForce = 0.1f;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if( _rb != null && _rb.isKinematic == false)
        {
            Vector3 radomDirection = Random.insideUnitSphere;
            _rb.AddForce(radomDirection * impulseForce, ForceMode.Impulse);

            Vector3 randomTorque = Random.insideUnitSphere;
            _rb.AddTorque(randomTorque * impulseForce, ForceMode.Impulse);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
