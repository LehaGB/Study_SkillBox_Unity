using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] private float radius = 0.1f;
    [SerializeField] private LayerMask ground;

    public bool IsGrounded => Physics.CheckSphere(transform.position, radius, ground);
}
