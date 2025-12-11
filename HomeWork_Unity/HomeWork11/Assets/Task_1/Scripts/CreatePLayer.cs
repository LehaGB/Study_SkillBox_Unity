using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePLayer : MonoBehaviour 
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CameraFollow cameraFollow;

    private CreatePlayerPrefab _createPlayerPrefab;

    private void Awake()
    {
        _createPlayerPrefab = new CreatePlayerPrefab();
        _createPlayerPrefab._playerPrefab = playerPrefab;
    }

    private void Start()
    {
        GameObject newPlayer = _createPlayerPrefab.CreatePlayer(transform);
        cameraFollow.SetTarget(newPlayer.transform); 
    }
}
