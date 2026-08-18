using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public Transform[] runners;
    public float rotationSpeed = 5f;

    private float _passDistance = 0.1f;
    private int _currentRunnerIndex = 0;
    private int _speed = 10;
   

    void Start()
    {
        if (runners == null || runners.Length == 0)
        {
            return;
        }
    }

    void Update()
    {
        MoveRunners();
    }
    public void MoveRunners()
    {
        
        Transform runnerPoint = runners[_currentRunnerIndex];

        int nextRunnerIndex = (_currentRunnerIndex + 1) % runners.Length;
        Transform nextRunner = runners[nextRunnerIndex];

        RotateTowardsTarget(runnerPoint, nextRunner);

        var distance = Vector3.Distance(runnerPoint.position, nextRunner.position);
        if(distance <= _passDistance)
        {
            _currentRunnerIndex = nextRunnerIndex;
        }
        else
        {
            runnerPoint.position = Vector3.MoveTowards(runnerPoint.position, nextRunner.position,
                _speed * Time.deltaTime);
        }
    }
    // Метод для поворота текущего бегуна в сторону следующего
    private void RotateTowardsTarget(Transform runner, Transform targetTransform)
    {
        Vector3 direction = (targetTransform.position - runner.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        runner.rotation = Quaternion.Slerp(runner.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

}
