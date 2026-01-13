using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CreatePLayer : MonoBehaviour 
{
    [SerializeField] private GameObject m_playerPrefab;
    [SerializeField] private CameraFollow m_cameraFollow;

    private AbstractPrefabCreate m_prefabCreate = new CreatePlayerPrefab();
    public static event System.Action<PlayerController> OnPlayerCreated;

    private GameObject _newPlayer;
    private void Start()
    {
        m_prefabCreate.Prefab = m_playerPrefab;
        _newPlayer = m_prefabCreate.CreatePrefab(transform);
        m_cameraFollow.SetTarget(_newPlayer.transform); 
        OnPlayerCreated?.Invoke(_newPlayer.GetComponent<PlayerController>());
    }
    private void OnDestroy()
    {
        if (_newPlayer != null)
        {
            Destroy(_newPlayer); 
        }
        OnPlayerCreated = null;      
    }
}
