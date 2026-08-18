using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AbstractCreatePrefab _createPrefab = new CreatePlayerPrefab();

    private GameObject _newPlayer;

    public GameObject playerPrefab;


    private void Awake()
    {
        _createPrefab.Prefab = playerPrefab;
    }

    private void Start()
    {
        CreatePlayerPrefab();
    }

    public void CreatePlayerPrefab()
    {        
        _newPlayer = _createPrefab.CreatePrefab(transform);
    }
}
