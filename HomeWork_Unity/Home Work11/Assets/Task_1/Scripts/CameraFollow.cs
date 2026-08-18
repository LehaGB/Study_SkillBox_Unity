using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform _target;

    [SerializeField] private Vector3 offset;

    

    private void LateUpdate()
    {
        if(_target  != null)
        {
            transform.position = _target.position + offset;
        }
    }
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
