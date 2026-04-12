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
    public float _horizontalInput;
    public float _verticalInput;
    [SerializeField] private float yPos;
    [SerializeField] private bool _hasDied = false;

    [Header("Objects")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ground;


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
        _horizontalInput = Input.GetAxis(GlobalStringVarieble.HORIZONTAL_AXIS);
        _verticalInput = Input.GetAxis(GlobalStringVarieble.VERTICAL_AXIS);

        _moveDirection = new Vector3(_horizontalInput, 0, _verticalInput).normalized;

        _movementPlayer.Move(_rbPlayer, _moveDirection, moveSpeed);

        _playerAnimation.PlayerAnim();
    }

    private void Death()
    {
        if (_player.transform.position.y <= yPos)
        {
            _hasDied = true;
            if (_hasDied)
            {
                EventsBus.Instance.TriggerPlayerDied();
                this.enabled = false;
            }
            _hasDied = false;     
        }
    }
}
