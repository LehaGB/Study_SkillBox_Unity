using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private Vector3 _movement;
    private PlayerMovement _playerMovement;


    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis(GlobalStringVarible.HORIZONTAL_AXIS);
        float vertical = Input.GetAxis(GlobalStringVarible.VERTICAL_AXIS);

        _movement = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        _playerMovement.MoveCharacter(_movement);
    }
}

