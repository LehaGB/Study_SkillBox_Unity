using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerInput _playerInput;

    [Header("Player animation")]
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        PlayerAnim();
    }


    public void PlayerAnim()
    {
        float horInput = _playerInput.InputHor;
        float vertInput = _playerInput.InputVer;

        bool IsMoving = Mathf.Abs(horInput) > 0.1 || Mathf.Abs(vertInput) > 0.1;

        animator.SetBool("IsMoving", IsMoving);
        animator.SetFloat("Hor", horInput);
        animator.SetFloat("Ver", vertInput);
    }
}
