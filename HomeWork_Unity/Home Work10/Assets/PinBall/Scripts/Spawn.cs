using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Spawn : BallController
{
    public GameObject spawnPrefab;

    [SerializeField] private float _posX;
    [SerializeField] private float _posZ;

    public void CreateDummy()
    {
        if(isActive)
        {
            float randomX = Random.Range(_posX, -_posX);
            float randomZ = Random.Range(_posZ, -_posZ);

            Vector3 spawnPosition = new Vector3(randomX, 0.181f, randomZ);

            GameObject newObject = Instantiate(spawnPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            return;
        }   
    }
}
