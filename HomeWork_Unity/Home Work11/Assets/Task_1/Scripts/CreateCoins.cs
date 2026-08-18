using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoins : MonoBehaviour
{
    [SerializeField] private GameObject m_coinPrefab;

    private AbstractPrefabCreate m_prefabCreator = new CreateCoinsPrefab();

    private void Start()
    {
        m_prefabCreator.Prefab = m_coinPrefab;
        m_prefabCreator.CreatePrefab(transform);
    }
}
