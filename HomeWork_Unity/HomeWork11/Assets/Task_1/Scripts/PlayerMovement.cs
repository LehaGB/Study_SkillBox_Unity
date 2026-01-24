using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour, IMovementController
    {

        private Rigidbody _rbPlayer;
        private Vector3 _movement;

        [SerializeField, Range(0,  10)] private float _moveSpeed = 3f;
        [SerializeField] private float _groundCheckDistance = 0.2f;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _jumpForce = 2f;
        


        public bool IsGrounded = false;

        private void Awake()
        {
            _rbPlayer = GetComponent<Rigidbody>();
            //_soundManager = GetComponent<SoundManager>();
        }
        public void Jump()
        {
            _rbPlayer.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);  
        }

        public void Move(Vector3 movement)
        {
            _rbPlayer.MovePosition(_rbPlayer.position + movement * _moveSpeed * Time.deltaTime);
        }

        public bool Checkgrounded()
        {
            IsGrounded = Physics.CheckSphere(transform.position, _groundCheckDistance, _groundMask);
            return IsGrounded;
        }
#if UNITY_EDITOR
        [ContextMenu("Reset moveSpeed")]
        public void RsetValues()
        {
            _moveSpeed = 2f;
        }
#endif
    }
}
