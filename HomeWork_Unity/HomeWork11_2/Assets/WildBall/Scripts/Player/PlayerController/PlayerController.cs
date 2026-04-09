using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using WildBall.Inputs;

public sealed class PlayerController : MonoBehaviour
{
    private IMovementPlayer _movementPlayer = new PlayerMovement();
    private PlayerAnimation _playerAnimation;

    private Rigidbody _rbPlayer;
    private Vector3 _moveDirection;


    [Header("Move")]
    public float horizontalInput;
    public float verticalInput;

    [Header("Objects")]
    public GameObject player;
    public GameObject ground;


    [SerializeField] private float moveSpeed = 2.0f;


    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
        _playerAnimation = GetComponent<PlayerAnimation>(); 
    }
    private void Update()
    {
        MovePlayer();
        Death();
    }


    public void MovePlayer()
    {
        horizontalInput = Input.GetAxis(GlobalStringVarieble.HORIZONTAL_AXIS);
        verticalInput = Input.GetAxis(GlobalStringVarieble.VERTICAL_AXIS);

        _moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        _movementPlayer.Move(_rbPlayer, _moveDirection, moveSpeed);

        _playerAnimation.PlayerAnim();
    }

    private void Death()
    {
        if (player.transform.position.y < ground.transform.position.y)
        {
            EventsBus.Instance.TriggerPlayerDied();
        }
    }
}
