using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerPrefab : MonoBehaviour, IPrefabFactory
{
    [SerializeField] private GameObject m_prefab;

    public GameObject Prefab {  get => m_prefab; set => m_prefab = value; }

    public GameObject CreatePrefab(Transform parentTransform)
    {
        Vector3 spawnPosPlayer = new Vector3(0, 0.12f, -49f);

        GameObject newPlayer = Instantiate(Prefab, spawnPosPlayer, Quaternion.identity);

        return newPlayer; 
    }
}
