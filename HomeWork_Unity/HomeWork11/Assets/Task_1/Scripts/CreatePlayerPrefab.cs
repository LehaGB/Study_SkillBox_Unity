using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerPrefab : MonoBehaviour, IPrefabFactory
{
    [SerializeField] private GameObject prefab;

    public GameObject Prefab {  get => prefab; set => prefab = value; }

    public GameObject CreatePrefab(Transform parentTransform)
    {
        Vector3 spawnPosPlayer = new Vector3(0, 0.12f, -49f);

        GameObject newPlayer = Instantiate(Prefab, spawnPosPlayer, Quaternion.identity);

        return newPlayer; 
    }
}
