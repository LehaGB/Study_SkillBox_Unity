using System;
using UnityEngine;
using UnityEngine.InputSystem;


//[RequireComponent(typeof(Rigidbody))]
//[AddComponentMenu("Control Script/Player Movement")]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rbPlayer;
    private Vector3 _moveDirection;

    [Header("Move")]
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float moveSpeed = 2.0f;

    [Header("Setting player jump")]
    [SerializeField] private float isDistanceGroundedCheck = 0.1f;
    [SerializeField] private float jumpImpulse = 2f;
    [SerializeField] private bool IsGrounded;

    [Header("LayerMask")]
    public LayerMask ground;

    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovementPlayer();
        PlayerJump();
    }

    private void MovementPlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        _moveDirection = new Vector3(-verticalInput, 0, horizontalInput).normalized;
        _rbPlayer.MovePosition(_rbPlayer.position + _moveDirection * 
            moveSpeed * Time.deltaTime);
    }

    private void PlayerJump()
    {
        if(CheckGrounded() && Input.GetButtonDown("Jump"))
        {
            _rbPlayer.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
        }
    }
    private bool CheckGrounded()
    {
        return Physics.CheckSphere(transform.position, isDistanceGroundedCheck, ground);
    }


}
