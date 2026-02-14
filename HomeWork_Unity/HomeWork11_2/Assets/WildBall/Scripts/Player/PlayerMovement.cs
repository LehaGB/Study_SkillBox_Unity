using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private GameObject _player;

    [Inject] TimeController _timeController;

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
