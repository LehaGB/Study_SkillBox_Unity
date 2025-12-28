using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksPrefab : MonoBehaviour, IPrefabFactory
{
    [SerializeField] private GameObject m_fireWorksPrefab;
    [SerializeField] private Transform m_firqworksSpawnPoint;

    public GameObject Prefab { get => m_fireWorksPrefab; set => m_fireWorksPrefab = value; }

    public GameObject CreatePrefab(Transform parent)
    {
        Vector3 pos = transform.position;
        GameObject m_fireworks = Instantiate(Prefab, m_firqworksSpawnPoint.position, Quaternion.identity);
        return m_fireworks;
    }
}
