using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMovementController
{
    private Animator _anim;
    private Rigidbody _rb;
    private readonly int _animIDSpeed = Animator.StringToHash("Speed");

    [SerializeField] private float _moveSpeed = 5f;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movemenDirection = new Vector3(horizontalInput, 0, verticalInput);

        float currentSped = movemenDirection.magnitude > 0 ? 0 : 1;

        _anim.SetFloat(_animIDSpeed, currentSped);

        if(movemenDirection.magnitude > 0)
        {
            _rb.MovePosition(_rb.position + movemenDirection * _moveSpeed * Time.deltaTime);
        }

        //transform.Translate(movemenDirection * _moveSpeed *Time.deltaTime, Space.World);
    }

    void Update()
    {
        Move();
    }
}
