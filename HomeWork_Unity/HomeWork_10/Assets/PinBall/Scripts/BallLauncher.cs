using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public AudioClip audioClip;
    private Rigidbody rb;

    private AudioSource audioSource;

    public float ballForce = 10f;
    public float ballForceCaosule = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        audioSource.Play();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Board"))
        {
            rb.AddForce(Vector3.forward * ballForceCaosule, ForceMode.Impulse);
        }
    }
}
