using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePreyer : MonoBehaviour
{

    private AbstractCreatePrefab _createPrefab = new CreatePlayerPrefab();
    private CameraController _cameraController;

    private GameObject _newPlayer;

    public GameObject playerPrefab;


    private void Awake()
    {
        _createPrefab.Prefab = playerPrefab;
        _cameraController = FindAnyObjectByType<CameraController>();
    }

    private void Start()
    {
        CreatePlayerPrefab();
    }

    public void CreatePlayerPrefab()
    {
        _newPlayer = _createPrefab.CreatePrefab(transform);
        _cameraController.SetTarget(_newPlayer.transform);
    }
}
