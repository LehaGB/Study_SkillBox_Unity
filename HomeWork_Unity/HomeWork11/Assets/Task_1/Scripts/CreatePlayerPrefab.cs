using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerPrefab : AbstractPrefabCreate
{

    [SerializeField] private GameObject m_prefab;

    public override GameObject Prefab {  get => m_prefab; set => m_prefab = value; }

    public override GameObject CreatePrefab(Transform parentTransform)
    {
        Vector3 spawnPosPlayer = new Vector3(0, 0.12f, -49f);

        GameObject newPlayer = GameObject.Instantiate(Prefab, spawnPosPlayer, Quaternion.identity, parentTransform);

        return newPlayer; 
    }
}
