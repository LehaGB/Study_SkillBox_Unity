using UnityEngine;

public class PlayerInput: MonoBehaviour
{

    public float InputHor {  get; private set; }
    public float InputVer {  get; private set; }
    public bool JumpPressed {  get; private set; }


    private void Update()
    {
        PlayerInputMove();
        JumpInput();
    }


    public void PlayerInputMove()
    {
        InputHor = Input.GetAxis("Horizontal");
        InputVer = Input.GetAxis("Vertical");
    }

    public void JumpInput()
    {
        JumpPressed = Input.GetButtonDown("Jump");
    }

    public void ConsumeJump()
    {
        JumpPressed = false;
    }
}
