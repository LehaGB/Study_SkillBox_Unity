using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 10.0f;  // �������� �������� �������.
    public float speed = 10.0f; // �������� ����������� ������.
    public float zoomSpeed = 10.0f;  // �������� �����������(���������) ������.
    public float maxZoom = 30f;  // ������������ ������������ ������.
    public float minZoom = -40f;  // ������������ �������������� ������.
    public float minCorner = -5.0f;
    public float maxCorner = 60.0f;

    private float _mult = 1f;  // ��������� �������� ������.

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");


        // ��������� �������� ��� ������� ������.
        float rotate = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            rotate = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotate = 1f;
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Rotate(Vector3.right * speed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime, Space.Self);
        }
        // ��������� �������.
        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        // �������� �������.
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);

        // ������������ �������.
        transform.Translate(new Vector3(horizontalInput, 0, verticallInput) * Time.deltaTime * _mult * speed, Space.Self);

        // ��� ������.
        transform.position += transform.up * zoomSpeed * Time.deltaTime * _mult * Input.GetAxis("Mouse ScrollWheel");

        // ����������� ��� ������.
        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, minZoom, maxZoom), transform.position.z);
    }
}
