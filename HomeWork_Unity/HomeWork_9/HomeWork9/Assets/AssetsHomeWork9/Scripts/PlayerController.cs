using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action LoadScene;
    public event Action BoomBadGuysAudio;

    private Rigidbody _rbSuperMan;
    //private RigidbodyConstraints _rigidbodyConstraints;

    public int power = 0;
    public float randomness = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        _rbSuperMan = GetComponent<Rigidbody>();
       // _rigidbodyConstraints = _rbSuperMan.constraints;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        _rbSuperMan.AddForce(1, 0, 0, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {

        GameObject otherObject = collision.gameObject;

        Rigidbody rbOtherOjbject = otherObject.GetComponent<Rigidbody>();
        if(rbOtherOjbject != null)
        {
            Vector3 direction = (rbOtherOjbject.transform.position - transform.position).normalized;
            Vector3 randomOffset = UnityEngine.Random.insideUnitSphere * randomness;
            Vector3 randomDirection = (direction + randomOffset).normalized;
            rbOtherOjbject.AddForce(randomDirection * power, ForceMode.Impulse);
            BoomBadGuysAudio?.Invoke();
        }  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            LoadScene?.Invoke();
            _rbSuperMan.isKinematic = true;
        }
    }
}
