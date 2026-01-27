using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WildBall.Inputs;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerAnimator _playerAnimator;
    private DeathPlayer _deathPlayer;

    private AudioSource _audioSource;
    private LoadLevelSceneManager _sceneManager;


    [HideInInspector] public Vector3 _movemenDirection;
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;


    private int _countCoin;

    public int CountCoin { get => _countCoin; set => _countCoin = value; }


    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _deathPlayer = GetComponent<DeathPlayer>();
    }

    void Update()
    {
        PlayerJump();
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

        if(transform.position.y < -1.5f)
        {
            DeathPlayer.Instanse.DeathPlayerS();
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