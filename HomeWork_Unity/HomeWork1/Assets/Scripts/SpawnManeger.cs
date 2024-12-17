using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManeger : MonoBehaviour
{
    [SerializeField] private GameObject[] carPrefab;
    private float spawnRangeZ = -47f;
    private float spawnRangeX = -35.97f;
    private float spawnRangeX2 = -40f;
    private float startSpawnCar = 1f;

    void Start()
    {
        // ����� ����� ����� ���� �����.
        InvokeRepeating("SpawnCar", startSpawnCar, Random.Range(5f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ����� �����.
    private void SpawnCar()
    {
        int carIndex = Random.Range(0, carPrefab.Length);
        Vector3 spawnPos =
            new(Random.Range(spawnRangeX, spawnRangeX2), 0, Random.Range(spawnRangeX, spawnRangeX2));
        Instantiate(carPrefab[carIndex], spawnPos, carPrefab[carIndex].transform.rotation);
    }
}
