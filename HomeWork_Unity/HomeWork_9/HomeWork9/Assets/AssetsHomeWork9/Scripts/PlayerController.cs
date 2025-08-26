using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rbSuperMan;

    public int power = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rbSuperMan = GetComponent<Rigidbody>();
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
            _rbSuperMan.AddForce(direction * power, ForceMode.Impulse);
        }
       
    }
}
