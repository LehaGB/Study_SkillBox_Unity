using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMovementController
{
    private Animator _anim;
    private Rigidbody _rb;

    private float _moveSpeed = 5f;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
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

        if(movemenDirection.magnitude > 1f)
        {
            movemenDirection.Normalize();
        }

        bool IsMovingForward = verticalInput > 0;
        bool IsMovingBack = verticalInput < 0;
        bool IsMovingRight = horizontalInput > 0;
        bool IsMovingLeft = horizontalInput < 0;


        _anim.SetBool("IsMovingForward", IsMovingForward);
        _anim.SetBool("IsMovingBack", IsMovingBack);
        _anim.SetBool("IsMovingLeft", IsMovingLeft);
        _anim.SetBool("IsMovingRight", IsMovingRight);

        if(movemenDirection.magnitude > 0)
        {
            _rb.MovePosition(_rb.position + movemenDirection * _moveSpeed * Time.deltaTime);
            _anim.SetBool("IsActive", false);
        }
        else
        {
            _anim.SetBool("IsActive", true);
            _anim.SetBool("IsMovingForward", false);
            _anim.SetBool("IsMovingLeft", false);
            _anim.SetBool("IsMovingRight", false);
            _anim.SetBool("IsMovingBack", false);
        }
    }
}
