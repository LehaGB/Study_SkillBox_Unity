using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IMovementController
{
    //public GameObject gameObject;
    private FireWorks m_fireWorks;
    private AudioSource m_audioSource;
    private SoundManager m_soundManager;
    private Animator m_anim;
    private Rigidbody m_rb;
    private int m_countCoin;

    private float m_moveSpeed = 5f;
    private bool m_IsGrounded = true;
    public bool IsActive = true;

    [SerializeField] private float m_jumpForce = 7f;
    [SerializeField] private float m_groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask m_groundMask;

    public int CountCoin { get => m_countCoin; set => m_countCoin = value; }

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody>();
        m_soundManager = SoundManager.Instance;
        //m_fireWorks = FireWorks.Instance;
    }
    private void Start()
    {
        m_fireWorks = FireWorks.Instance;
        if(m_fireWorks == null)
        {
            m_fireWorks = FindObjectOfType<FireWorks>();
        }
    }

    void Update()
    {
        Move();
        Checkgrounded();
        if (m_IsGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    // Звук сбора монетки.
    private void SoundCoin()
    {
        if (m_soundManager != null)
        {
            m_soundManager.PlayCoinSound();
        }       
    }

    // Проверка, на земле ли.
    private void Checkgrounded()
    {
        m_IsGrounded = Physics.CheckSphere(transform.position, m_groundCheckDistance, m_groundMask);
    }


    // Прыжок.
    public void Jump()
    {
        m_rb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        m_soundManager.PlayJumpSound();
    }


    // Движение.
    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movemenDirection = new Vector3(horizontalInput, 0, verticalInput);

        if(movemenDirection.magnitude > 1f)
        {
            movemenDirection.Normalize();
        }

        bool IsMovingForward = verticalInput > 0;
        bool IsMovingBack = verticalInput < 0;
        bool IsMovingRight = horizontalInput > 0;
        bool IsMovingLeft = horizontalInput < 0;


        m_anim.SetBool("IsMovingForward", IsMovingForward);
        m_anim.SetBool("IsMovingBack", IsMovingBack);
        m_anim.SetBool("IsMovingLeft", IsMovingLeft);
        m_anim.SetBool("IsMovingRight", IsMovingRight);

        if(movemenDirection.magnitude > 0)
        {
            m_rb.MovePosition(m_rb.position + movemenDirection * m_moveSpeed * Time.deltaTime);
            m_anim.SetBool("IsActive", false);
        }
        else
        {
            m_anim.SetBool("IsActive", true);
            m_anim.SetBool("IsMovingForward", false);
            m_anim.SetBool("IsMovingLeft", false);
            m_anim.SetBool("IsMovingRight", false);
            m_anim.SetBool("IsMovingBack", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin") && IsActive)
        {
            Destroy(other.gameObject);
            CountCoin++;
            m_soundManager.PlayCoinSound();
        }
        if (other.gameObject.CompareTag("Level"))
        {
            m_fireWorks.StartFireworks();
        }
        //if(other.gameObject.CompareTag("Level") && IsActive)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }
}