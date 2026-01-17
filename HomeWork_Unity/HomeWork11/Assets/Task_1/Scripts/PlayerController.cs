using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using UnityEditor;
using UnityEngine.SceneManagement;
using WildBall.Inputs;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerAnimator _playerAnimator;
    private int m_countCoin;
    private AudioSource m_audioSource;

    [SerializeField] private SoundManager _soundManager;    

    [HideInInspector] public Vector3 _movemenDirection;
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;

    public bool IsActive = true;
    public int CountCoin { get => m_countCoin; set => m_countCoin = value; }

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _soundManager = SoundManager.Instance;
    }

    void Update()
    {
        bool ground =  _playerMovement.Checkgrounded();
        if (Input.GetButtonDown(GlobalStringVarible.JUMP_BUTTON) && ground)
        {   
            _playerMovement.Jump();
            _soundManager.PlayJumpSound();
        }
        else
        {
            ground = false;
        }
    }

    private void FixedUpdate()
    {
        MovementCharacter();
    }

    // Звук сбора монетки.
    private void SoundCoin()
    {
        if (_soundManager != null)
        {
            _soundManager.PlayCoinSound();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin") && IsActive)
        {
            Destroy(other.gameObject);
            CountCoin++;
            _soundManager.PlayCoinSound();
        }
        if (other.gameObject.CompareTag("Level"))
        {
            _soundManager._audioSource.Stop();
            _soundManager.PlayVictoryClip();
            
            StartCoroutine(NewLevel());
        }
    }
    IEnumerator NewLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}