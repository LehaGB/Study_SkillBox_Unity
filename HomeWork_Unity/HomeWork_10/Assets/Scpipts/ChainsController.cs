using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsController : MonoBehaviour
{
    public float force = 1f;

    private void Start()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        if (rigidbodies != null)
        {
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.AddForce(Vector3.back * force, ForceMode.Impulse);
            }
        }
    }
}
