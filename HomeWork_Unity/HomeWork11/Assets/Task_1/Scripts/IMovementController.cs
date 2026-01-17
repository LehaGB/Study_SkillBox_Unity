using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementController
{
    void Move(Vector3 mov);
    void Jump();
}
