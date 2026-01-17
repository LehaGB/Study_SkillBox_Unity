using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator m_anim;

    private PlayerController _playerController;


    private void Awake()
    {
        m_anim = GetComponentInChildren<Animator>();
        _playerController = GetComponent<PlayerController>();
    }


    public void PlayerAnimtion()
    {
        bool IsMovingForward = _playerController.verticalInput > 0;
        bool IsMovingBack = _playerController.verticalInput < 0;
        bool IsMovingRight = _playerController.horizontalInput > 0;
        bool IsMovingLeft = _playerController.horizontalInput < 0;


        m_anim.SetBool("IsMovingForward", IsMovingForward);
        m_anim.SetBool("IsMovingBack", IsMovingBack);
        m_anim.SetBool("IsMovingLeft", IsMovingLeft);
        m_anim.SetBool("IsMovingRight", IsMovingRight);

        if (_playerController._movemenDirection.magnitude > 0)
        {

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
}
