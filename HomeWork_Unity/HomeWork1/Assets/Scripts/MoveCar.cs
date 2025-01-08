using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 2f;
    private float maxSpeed = 6f;
    private float upperBoundZ = 47f;
    private float upperBoundX = 48f;


    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        // Движение автомобиля.
        Vector3 moveDirection = transform.forward;
        transform.position += moveDirection * Random.Range(speed, maxSpeed) * Time.deltaTime;

        // Удаление автомобиля.
        if (transform.position.z >= upperBoundZ)
        {
            Destroy(gameObject);
        }
    }
}
