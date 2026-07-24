using System;
using UnityEngine;
using UnityEngine.InputSystem;


//[RequireComponent(typeof(Rigidbody))]
//[AddComponentMenu("Control Script/Player Movement")]
public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;

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


    public float HorizontalInput {  get { return horizontalInput; } set { horizontalInput  = value; } }
    public float VerticalInput {  get { return verticalInput; } set { verticalInput = value; } }


    [Header("LayerMask")]
    public LayerMask ground;

    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        MovementPlayer();
        PlayerJump();
    }

    private void MovementPlayer()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        _moveDirection = new Vector3(-VerticalInput, 0, HorizontalInput).normalized;
        _rbPlayer.MovePosition(_rbPlayer.position + _moveDirection * 
            moveSpeed * Time.deltaTime);

        _playerAnimation.PlayerAnim();
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
