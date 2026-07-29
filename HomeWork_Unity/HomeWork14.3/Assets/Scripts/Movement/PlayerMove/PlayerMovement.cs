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

    [Header("Partical Effect")]
    [SerializeField] private ParticleSystem fireEffect;


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
        InputMovePlayer();
        PlayerJump();
    }


    private void FixedUpdate()
    {
        MovementPlayer();
    }


    private void InputMovePlayer()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        //_playerAnimation.PlayerAnim(HorizontalInput, VerticalInput);
    }


    private void MovementPlayer()
    {
        _moveDirection = new Vector3(-VerticalInput, 0, HorizontalInput).normalized;
        _rbPlayer.MovePosition(_rbPlayer.position + (_moveDirection * 
            moveSpeed * Time.deltaTime));  

        if(_moveDirection != Vector3.zero)
        {
            if (!fireEffect.isPlaying)
            {
                fireEffect.Play();
            }
        }
        else
        {
            if (fireEffect.isPlaying)
            {
                fireEffect.Stop();
            }
        }
    }


    private void PlayerJump()
    {
        if(!CheckGrounded()) return;

        if(Input.GetButtonDown("Jump"))
        {
            _rbPlayer.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
        }
    }


    private bool CheckGrounded()
    {
        Vector2 checkPos = transform.position + Vector3.down * 0.9f;
        return Physics.CheckSphere(transform.position, isDistanceGroundedCheck, ground);
    }
}
