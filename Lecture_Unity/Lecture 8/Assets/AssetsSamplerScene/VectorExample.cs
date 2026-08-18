using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorExample : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public float speed;
    public bool go;

    private Vector3 _target;
    //private float _point1;
    //private float _point2;

    void Start()
    {
        _target = point1.position;
        //vec.Set(5, 5, 5);
        //transform.position = point1.position;
        //_point1 = Vector3.Angle(point1.position, point2.position);
        //Debug.Log($"{_point1}");
        //transform.rotation = Quaternion.Euler(45, 45, 45);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0.5f);
        if (go)
        {
            transform.position =  Vector3.MoveTowards(transform.position, _target, 
                Time.deltaTime * speed);
        }
        if(transform.position == _target)
        {
            if(_target == point1.position)
            {
                _target = point2.position;
            }
            else if(_target == point2.position)
            {
                _target = point1.position;
            }
            transform.LookAt(_target);
        }
        //transform.position = Vector3.Lerp(transform.position, point1.position, 0.1f * Time.deltaTime);

    }
}
