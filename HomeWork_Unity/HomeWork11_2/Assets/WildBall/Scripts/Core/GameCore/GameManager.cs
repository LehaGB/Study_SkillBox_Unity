using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ICreatePrefab _createPrefab = new CreatePlayerPrefab();

    private GameObject _newPlayer;

    public GameObject playerPrefab;

    private void Start()
    {
        CreatePlayerPrefab();
    }

    public void CreatePlayerPrefab()
    {
        _createPrefab.Prefab = playerPrefab;
        _newPlayer = _createPrefab.CreatePrefab(transform);
    }
}
