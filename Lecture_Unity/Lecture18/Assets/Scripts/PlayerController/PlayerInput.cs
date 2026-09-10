using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 InputHor;

    private void Update()
    {
        PlayerInputMove();
    }

    public void PlayerInputMove()
    {
        InputHor.x = Input.GetAxisRaw("Horizontal");
        InputHor = InputHor.normalized;
    }
}
