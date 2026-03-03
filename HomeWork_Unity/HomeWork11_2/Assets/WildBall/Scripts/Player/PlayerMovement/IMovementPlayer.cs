using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementPlayer 
{
    void Move(Rigidbody rbMove, Vector3 move, float moveSpeed);

    void Jump(Rigidbody rbJump, float jumpImpulse);
}
