using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerPrefab : AbstractPrefabCreate
{

    [SerializeField] private GameObject _prefab;

    public override GameObject Prefab {  get => _prefab; set => _prefab = value; }

    public override GameObject CreatePrefab(Transform parentTransform)
    {
        Vector3 spawnPosPlayer = new Vector3(0, 0.12f, -14f);

        GameObject newPlayer = GameObject.Instantiate(Prefab, spawnPosPlayer, Quaternion.identity, parentTransform);

        return newPlayer; 
    }
}
