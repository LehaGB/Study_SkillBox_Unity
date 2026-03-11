using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private WildBall.Inputs.PlayerJump _playerJump;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerController = FindAnyObjectByType<PlayerController>();
        _playerJump = GetComponent<WildBall.Inputs.PlayerJump>();
    }

    public void PlayerAnim()
    {
        float horInput = _playerController.horizontalInput;
        float vertInput = _playerController.verticalInput;

        bool IsMoving = Mathf.Abs(horInput) > 0.1f || Mathf.Abs(vertInput) > 0.1f;

        _playerAnimator.SetBool("IsMoving", IsMoving);
        _playerAnimator.SetBool("IsGround", _playerJump.IsGrounded);

        _playerAnimator.SetFloat("Hor", horInput);
        _playerAnimator.SetFloat("Ver", vertInput);
    }
}
