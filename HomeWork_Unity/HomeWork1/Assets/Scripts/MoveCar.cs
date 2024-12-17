using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 2f;
    private float maxSpeed = 6f;
    private float upperBound = 47f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        if (transform.position.z >= upperBound)
        {
            Destroy(gameObject);
        }
    }
}
