using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    private void Update()
    {
        PlayerAnim();
    }

    public void PlayerAnim()
    {
        Vector2 inputHor = PlayerBase.Instance.playerInput.InputHor;

        animator.SetFloat("IsRunning", inputHor.sqrMagnitude);

        if(inputHor.x != 0)
        {
            spriteRenderer.flipX = inputHor.x < 0;
        }
    }
}
