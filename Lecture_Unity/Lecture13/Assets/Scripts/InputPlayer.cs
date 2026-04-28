using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public float speed = 2.0f;
    public float gravity = -9.8f;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horInput, 0, verInput).normalized;
        direction = Vector3.ClampMagnitude(direction, speed);

        direction.y = gravity;
        direction *= Time.deltaTime;

        direction = transform.TransformDirection(direction);

        _controller.Move(direction);

    }
}
