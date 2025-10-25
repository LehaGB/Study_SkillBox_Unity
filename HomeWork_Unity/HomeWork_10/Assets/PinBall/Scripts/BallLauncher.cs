using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Rigidbody rb;

    public float ballForce = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchBall()
    {
        rb.AddForce(transform.forward * ballForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            rb.AddForce(Vector3.forward * ballForce, ForceMode.Impulse); 
        }
    }
}
