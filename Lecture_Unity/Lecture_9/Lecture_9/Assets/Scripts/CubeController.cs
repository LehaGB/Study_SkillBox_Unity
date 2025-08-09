using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeController : MonoBehaviour
{
    public TextMeshProUGUI cubeText;
    public TextMeshProUGUI cubeText1;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(2, 0, 0, ForceMode.Force);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    cubeText.text = $"Collision detected! {collision.gameObject.name}";
    //}

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
