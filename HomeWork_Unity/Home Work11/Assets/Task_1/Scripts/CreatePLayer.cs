using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CreatePLayer : MonoBehaviour 
{
    public GameObject _playerPrefab;
    public GameObject deidCanvas;
    public GameObject levelCanvas;
    [SerializeField] private CameraFollow _cameraFollow;

    private AbstractPrefabCreate _prefabCreate = new CreatePlayerPrefab();
    public static event System.Action<PlayerController> OnPlayerCreated;

    private GameObject _newPlayer;

    private void Start()
    {
        _prefabCreate.Prefab = _playerPrefab;
        _newPlayer = _prefabCreate.CreatePrefab(transform);
        _cameraFollow.SetTarget(_newPlayer.transform); 
        OnPlayerCreated?.Invoke(_newPlayer.GetComponent<PlayerController>());
    }
}
