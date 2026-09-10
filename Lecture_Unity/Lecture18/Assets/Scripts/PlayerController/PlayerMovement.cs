using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    public Vector2 MoveDirection { get; private set; }
    public bool IsMoving { get; private set; }

    public float speedMovePlayer = 2.0f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        MoveDirection = new Vector2(PlayerBase.Instance.playerInput.InputHor.x, 0).normalized;

        rigidbody2D.MovePosition(rigidbody2D.position + (MoveDirection * speedMovePlayer * Time.fixedDeltaTime));
    }
}
