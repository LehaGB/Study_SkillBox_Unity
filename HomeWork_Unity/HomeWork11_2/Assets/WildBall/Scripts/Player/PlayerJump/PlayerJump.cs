using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using WildBall.Inputs;

namespace WildBall.Inputs
{
    public class PlayerJump : MonoBehaviour
    {
        //private IAudioManager _audioManager = new AudioManager();
        private Rigidbody _playerRb;
        private AudioSource _playerAudioSource;

        [Header("Setting player jump")]
        public float isDistanceGroundedCheck = 0.1f;
        public float jumpImpuls = 2f;
        public bool IsGrounded;

        [Header("LayerMask")]
        public LayerMask ground;

        [Header("Audio clickClip")]
        public AudioClip jumpClip;

        void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            _playerAudioSource = GetComponent<AudioSource>();
        }


        void Update()
        {
            Jump();
        }


        public void Jump()
        {
            //bool ground = CheckGrounded();
            if (CheckGrounded() && Input.GetButtonDown(GlobalStringVarieble.JUMP_BUTTON))
            {
                _playerRb.AddForce(Vector3.up * jumpImpuls, ForceMode.Impulse);
                _playerAudioSource.PlayOneShot(clip: jumpClip);
            }
            else if (Input.GetButtonDown(GlobalStringVarieble.JUMP_BUTTON) && !IsGrounded)
            {
                Debug.Log("Player is in air, cannot jump again.");
            }
        }

        public bool CheckGrounded()
        {
            return Physics.CheckSphere(transform.position,
                isDistanceGroundedCheck, ground);
        }
    }
}
