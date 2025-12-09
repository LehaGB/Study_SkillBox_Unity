using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoins : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    private CreateCoinsPrefab _prefabCreator;


    private void Awake()
    {
        _prefabCreator = new CreateCoinsPrefab();
        _prefabCreator._coinPrefab = _coinPrefab;
    }

    private void Start()
    {
        _prefabCreator.CreatePrefab(transform);
    }
}
