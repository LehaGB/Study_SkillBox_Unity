using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float power;
    public float radius;

    // Update is called once per frame
    void Update()
    {
        Boom();
    }
    private void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rb in blocks)
        {
            var distance = Vector3.Distance(transform.position, rb.transform.position);
            if (distance < radius)
            {
                Vector3 direction = rb.transform.position - transform.position;
                rb.AddForce(direction.normalized * power * (radius - distance), ForceMode.Impulse);
            }
        }
    }
}
