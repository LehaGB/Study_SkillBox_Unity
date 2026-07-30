using System;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("Control Script/Player Movement")]
public class PlayerMovement : MonoBehaviour
{
    [Header("Speed Player")]
    [SerializeField] private float moveSpeed = 2.0f;
    private Rigidbody _rbPlayer;
    private PlayerInput _playerInput;
    public Vector3 MoveDirection {  get; private set; }
    public bool IsMoving { get; private set; }
    

    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        MoveDirection = new Vector3(-_playerInput.InputVer, 0, _playerInput.InputHor).normalized;
        _rbPlayer.MovePosition(_rbPlayer.position + (MoveDirection *
            moveSpeed * Time.fixedDeltaTime));
        IsMoving = MoveDirection != Vector3.zero;
    }
}
