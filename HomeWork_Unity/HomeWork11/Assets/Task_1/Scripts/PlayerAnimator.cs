using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private PlayerController _playerController;


    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _playerController = GetComponent<PlayerController>();
    }


    public void PlayerAnimtion()
    {
        bool IsMovingForward = _playerController.verticalInput > 0;
        bool IsMovingBack = _playerController.verticalInput < 0;
        bool IsMovingRight = _playerController.horizontalInput > 0;
        bool IsMovingLeft = _playerController.horizontalInput < 0;


        _anim.SetBool("IsMovingForward", IsMovingForward);
        _anim.SetBool("IsMovingBack", IsMovingBack);
        _anim.SetBool("IsMovingLeft", IsMovingLeft);
        _anim.SetBool("IsMovingRight", IsMovingRight);

        if (_playerController._movemenDirection.magnitude > 0)
        {

            _anim.SetBool("IsActive", false);
        }
        else
        {
            _anim.SetBool("IsActive", true);
            _anim.SetBool("IsMovingForward", false);
            _anim.SetBool("IsMovingLeft", false);
            _anim.SetBool("IsMovingRight", false);
            _anim.SetBool("IsMovingBack", false);
        }
    }
}
