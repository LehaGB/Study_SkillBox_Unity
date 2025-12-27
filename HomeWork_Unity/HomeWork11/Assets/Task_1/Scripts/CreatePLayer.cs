using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CreatePLayer : MonoBehaviour 
{
    [SerializeField] private GameObject m_playerPrefab;
    [SerializeField] private CameraFollow m_cameraFollow;

    private IPrefabFactory m_createPlayerPrefab;
    public static event System.Action<PlayerController> OnPlayerCreated;

    private void Awake()
    {
        m_createPlayerPrefab = GetComponent<CreatePlayerPrefab>();
        if(m_createPlayerPrefab == null)
        {
            m_createPlayerPrefab = gameObject.AddComponent<CreatePlayerPrefab>();
        }
        m_createPlayerPrefab.Prefab = m_playerPrefab;
    }

    private void Start()
    {
        GameObject newPlayer = m_createPlayerPrefab.CreatePrefab(transform);
        m_cameraFollow.SetTarget(newPlayer.transform); 
        OnPlayerCreated?.Invoke(newPlayer.GetComponent<PlayerController>());
    }
}
