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
    private CreatePLayer _createPLayer;

    private AudioSource _audioSource;
    private LoadLevelSceneManager _sceneManager;

    //private GameObject buttonPrefab;
    public GameObject deidPlayerCanvas;
    public GameObject buttonCanvas;

    [HideInInspector] public Vector3 _movemenDirection;
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;


    private int _countCoin;

    public int CountCoin { get => _countCoin; set => _countCoin = value; }


    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _createPLayer = GetComponent<CreatePLayer>();
    }

    void Update()
    {
        PlayerJump();
    }

    private void FixedUpdate()
    {
        MovementCharacter();
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
            _createPLayer.deidCanvas.SetActive(true);
            _createPLayer.levelCanvas.SetActive(value: false);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        else
        {
            _createPLayer.deidCanvas.SetActive(false);
            _createPLayer.levelCanvas.SetActive(value: true);
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