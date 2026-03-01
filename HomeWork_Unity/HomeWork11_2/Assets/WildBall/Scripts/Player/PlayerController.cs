using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _movementSpeed = 100;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Rotate(Vector3.up, _movementSpeed * Time.deltaTime);
    }  
}
