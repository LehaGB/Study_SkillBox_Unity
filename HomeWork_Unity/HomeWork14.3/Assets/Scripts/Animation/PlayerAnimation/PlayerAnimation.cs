using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement _mMovement;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _mMovement = GetComponent<PlayerMovement>();
    }

    public void PlayerAnim()
    {
        float horInput = _mMovement.HorizontalInput;
        float vertInput = _mMovement.VerticalInput;

        bool IsMoving = Mathf.Abs(horInput) > 0.1 || Mathf.Abs(vertInput) > 0.1;

        animator.SetBool("IsMoving", IsMoving);
        animator.SetFloat("Hor", horInput);
        animator.SetFloat("Ver", vertInput);
    }

}
