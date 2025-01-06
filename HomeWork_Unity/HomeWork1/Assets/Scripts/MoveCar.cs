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
        RotateCar();
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
    public void RotateCar()
    {
        Vector3 moveDirection = transform.forward;
        if (CompareTag("Taxi") && transform.position.z > 7.5)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            transform.position += moveDirection * Time.deltaTime;
        }
        else if (transform.position.x >= upperBoundX)
        {
            Destroy(gameObject);
        }
    }
}
