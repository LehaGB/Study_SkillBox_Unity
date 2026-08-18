using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rbSuperMan;
    private CameraController _cameraController;

    public event Action LoadScene;
    public event Action BoomBadGuysAudio;

    public int power = 0;
    public float randomness = 0.3f;

    public bool isActive = true;

    void Start()
    {
        _cameraController = FindObjectOfType<CameraController>();
        _rbSuperMan = GetComponent<Rigidbody>();
    }

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
        if (other.gameObject && isActive)
        {
            LoadScene?.Invoke();
            _rbSuperMan.isKinematic = true;

            if(_cameraController != null)
            {
                _cameraController.StopMusic();
            }
        }
        isActive = false;
    }
}
