using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeController : MonoBehaviour
{
    public TextMeshProUGUI cubeText;
    



    private Rigidbody rb;
    private BoxCollider boxCollider;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, 2, ForceMode.Force);
        //if (transform.position.z > 6)
        //{
        //    boxCollider.isTrigger = true;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        string a = collision.gameObject.name;
        cubeText.text = $"Collision detected! {a}";
        if(a == "LoLo")
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    cubeText1.text = $"Collision lost! {collision.gameObject.transform.position}";
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.name == "SkillBox")
    //    {
    //        cubeText.text = $"Yay! {other.gameObject.name}";

    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    cubeText1.text = $"Trigger Loas!";

    //}
}
