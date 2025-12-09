using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePLayer : MonoBehaviour 
{
    [SerializeField] private GameObject playerPrefab;

    private CreatePlayerPrefab _createPlayerPrefab;

    private void Awake()
    {
        _createPlayerPrefab = new CreatePlayerPrefab();
        _createPlayerPrefab._playerPrefab = playerPrefab;
    }

    private void Start()
    {
        _createPlayerPrefab.CreatePrefab(transform);
    }
}
