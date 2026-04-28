using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public Vector3 offset;

    private void FixedUpdate()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        transform.position = player.transform.position + offset;
    }
}
