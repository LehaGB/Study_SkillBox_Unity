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

   // [SerializeField] private LayerMask groundMask;

    [SerializeField] private float moveSpeed = 2.0f;
  //  [SerializeField] private float jumpImpuls = 2.0f;
  //  [SerializeField] private bool IsGrounded = false;
   // [SerializeField] private float isDistanceGroundedCheck = 0.1f;


    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxis(GlobalStringVarieble.HORIZONTAL_AXIS);
        float verticalInput = Input.GetAxis(GlobalStringVarieble.VERTICAL_AXIS);

        _moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        _movementPlayer.Move(_rbPlayer, _moveDirection, moveSpeed);
    }
}
