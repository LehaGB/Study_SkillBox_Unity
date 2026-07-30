using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump power")]
    [SerializeField] private float jumpImpulse = 2f;

    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private PlayerGroundCheck _check;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _check = GetComponent<PlayerGroundCheck>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_check.IsGrounded) return;

        if (_input.JumpPressed)
        {
            _rigidbody.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
            _input.ConsumeJump();
        }
    }
}
