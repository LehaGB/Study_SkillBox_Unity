using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoins : MonoBehaviour
{
    [SerializeField] private GameObject m_coinPrefab;

    private IPrefabFactory m_prefabCreator;


    private void Awake()
    {
        m_prefabCreator = GetComponent<CreateCoinsPrefab>();
        if(m_prefabCreator == null)
        {
            m_prefabCreator = gameObject.AddComponent<CreateCoinsPrefab>();
        }
        m_prefabCreator.Prefab = m_coinPrefab;
    }

    private void Start()
    {
        m_prefabCreator.CreatePrefab(transform);
    }
}
