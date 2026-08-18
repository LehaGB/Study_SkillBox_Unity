using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

public class PlayerMovement : IMovementPlayer
{

    public void Jump(Rigidbody rbJump, float jumpImpulse)
    {
        rbJump.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
    }

    public void Move(Rigidbody rbMove, Vector3 moveVec, float moveSpeed)
    {
        rbMove.MovePosition(rbMove.position + moveVec * moveSpeed * Time.fixedDeltaTime);
    }
}
