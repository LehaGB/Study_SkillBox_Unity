using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WildBall.Inputs;

public sealed class PlayerController : MonoBehaviour
{
    private IMovementPlayer _movementPlayer = new PlayerMovement();

    private Rigidbody _rbPlayer;
    private Vector3 _moveDirection;
    private BoxCollider _boxCollider;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float jumpImpuls = 2.0f;
    [SerializeField] private bool IsGrounded = false;
    [SerializeField] private float isDistanceGroundedCheck = 0.2f;

    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }
    private void lateUpdate()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
       PlayerJump();
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxis(GlobalStringVarieble.HORIZONTAL_AXIS);
        float verticalInput = Input.GetAxis(GlobalStringVarieble.VERTICAL_AXIS);

        _moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        _movementPlayer.Move(_rbPlayer, _moveDirection, moveSpeed);
    }

    public void PlayerJump()
    {
        
        if(CheckGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _movementPlayer.Jump(_rbPlayer, jumpImpuls);
        }       
    }

    public bool CheckGrounded()
    {
        Vector3 cubeBottom = new Vector3(_boxCollider.bounds.center.x, _boxCollider.bounds.min.y,
            _boxCollider.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_boxCollider.bounds.center, cubeBottom, 
            isDistanceGroundedCheck, groundMask, QueryTriggerInteraction.Ignore);
        return grounded;
    }
}
