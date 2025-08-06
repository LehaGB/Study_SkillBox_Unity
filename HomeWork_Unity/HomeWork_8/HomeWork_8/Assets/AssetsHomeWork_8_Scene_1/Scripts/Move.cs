using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    public Vector3[] targets = new Vector3[4];
    public float stoppingDistance = 0.1f;

    private int _currentPointIndex = 0;
    private bool _forward = true;
    private int _speed = 3;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();
    }
    public void MoveCube()
    {
        if(targets == null || targets.Length == 0)
        {
            return;
        }
        Vector3 targetPoint = targets[_currentPointIndex];

        var distance = Vector3.Distance(transform.position, targetPoint);
        if(distance  > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint,
                _speed * Time.deltaTime);
            transform.LookAt(targetPoint);
        }
        else
        {
            // Если достигли точки, выбираем следующую
            UpdateCurrentPointIndex();
        }
    }
    public void UpdateCurrentPointIndex()
    {
        if (_forward)
        {
            _currentPointIndex++;
            if(_currentPointIndex >= targets.Length)
            {
                _currentPointIndex = targets.Length - 2;
                _forward = false;
            }
        }
        else
        {
            _currentPointIndex--;
            if(_currentPointIndex < 0)
            {
                _currentPointIndex = 1;
                _forward = true;
            }
        }
    }
}
