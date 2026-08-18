using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoomController : MonoBehaviour
{
    public TextMeshProUGUI timeToExplosionText;

    public float timeToExplosion;
    public float power;
    public float radius;


    private void Update()
    {
        timeToExplosion -= Time.deltaTime;
        timeToExplosionText.text = $"{timeToExplosion}";

        Boom();
    }


    private void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach(Rigidbody rb in blocks)
        {
            var distance = Vector3.Distance(transform.position, rb.transform.position);
            if (distance < radius)
            {
                Vector3 direction = rb.transform.position - transform.position;
                rb.AddForce(direction.normalized * power * (radius - distance), ForceMode.Impulse);
            }
        }
        timeToExplosion = 3;
    }
}

