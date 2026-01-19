using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CreatePLayer : MonoBehaviour 
{
    public GameObject _playerPrefab;
    [SerializeField] private CameraFollow _cameraFollow;

    private AbstractPrefabCreate m_prefabCreate = new CreatePlayerPrefab();
    public static event System.Action<PlayerController> OnPlayerCreated;

    private GameObject _newPlayer;

    private void Start()
    {
        m_prefabCreate.Prefab = _playerPrefab;
        _newPlayer = m_prefabCreate.CreatePrefab(transform);
        _cameraFollow.SetTarget(_newPlayer.transform); 
        OnPlayerCreated?.Invoke(_newPlayer.GetComponent<PlayerController>());
    }
}
