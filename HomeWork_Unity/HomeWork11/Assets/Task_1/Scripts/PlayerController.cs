using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using WildBall.Inputs;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerAnimator _playerAnimator;

    private AudioSource _audioSource;
    private LoadLevelSceneManager _sceneManager;

    private int _countCoin;
    //private int _indexLevel;  

    [HideInInspector] public Vector3 _movemenDirection;
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;

    public float posPlayerDeath = -1.5f;

    //public bool IsGrounded = true;
    public int CountCoin { get => _countCoin; set => _countCoin = value; }
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        
    }

    private void Start()
    {

    }

    void Update()
    {
        PlayerJump();
        DeathPlayer();
    }

    private void FixedUpdate()
    {
        MovementCharacter();
    }

    // Звук сбора монетки.
    private void SoundCoin()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayCoinSound();
        }       
    }


    // Движение.
    public void MovementCharacter()
    {
        horizontalInput = Input.GetAxis(GlobalStringVarible.HORIZONTAL_AXIS);
        verticalInput = Input.GetAxis(GlobalStringVarible.VERTICAL_AXIS);

        _movemenDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (_movemenDirection.magnitude > 1f)
        {
            _movemenDirection.Normalize();
        }
        _playerMovement.Move(_movemenDirection);
        _playerAnimator.PlayerAnimtion();
    }

    private void DeathPlayer()
    {
        if (transform.position.y < posPlayerDeath)
        {
            SoundManager.Instance._audioSource.Stop();
            Destroy(gameObject);
        }
    }

    private void PlayerJump()
    {
        bool Ground = _playerMovement.Checkgrounded();
        if (Input.GetButtonDown(GlobalStringVarible.JUMP_BUTTON) && Ground)
        {
            Debug.Log("Пытаюсь прыгнуть");
            _playerMovement.Jump();
            SoundManager.Instance.PlayJumpSound();           
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CountCoin++;
            SoundManager.Instance.PlayCoinSound();
        }
        if (other.gameObject.CompareTag("Level"))
        {
            if(SoundManager.Instance != null)
            {
                SoundManager.Instance._audioSource.Stop();
                SoundManager.Instance.PlayVictoryClip();
            }
        }

    }
    //private void OnTriggerExit(Collider other)
    //{
    //    SoundManager.Instance.victoryClip = null;
    //    IsGrounded = false;
    //}
}