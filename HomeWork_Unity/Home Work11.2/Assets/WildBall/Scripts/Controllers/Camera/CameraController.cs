using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    public void LateUpdate()
    {
        if(_player != null)
        {
            transform.position = _player.position + _offset;
        }
    }
    public void SetTarget(Transform target)
    {
        _player = target;
    }
}
