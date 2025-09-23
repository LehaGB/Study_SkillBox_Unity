using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{

    private Rigidbody _rigidbody;
    public Vector3 direction = Vector3.right;

    public float forceMultiplier = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(direction * forceMultiplier, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
