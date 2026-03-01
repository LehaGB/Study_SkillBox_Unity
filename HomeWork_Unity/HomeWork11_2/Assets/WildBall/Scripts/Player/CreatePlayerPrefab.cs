using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class CreatePlayerPrefab : AbstractCreatePrefab
{

    [SerializeField] private GameObject _playerPrefab;

    public override GameObject Prefab { get => _playerPrefab; set => _playerPrefab = value; }

    public override GameObject CreatePrefab(Transform parentPlayer)
    {
        Vector3 startPosPlayer = new Vector3(-0.21f, 0.96f, 0f);
        GameObject newPlayer  = GameObject.Instantiate(Prefab, startPosPlayer, Quaternion.identity, parentPlayer);
        return newPlayer;
    }

    public override GameObject DestroyPrefab(Transform destroyPlayer)
    {
        throw new NotImplementedException();
    }

    public override GameObject MovementPrefab(Transform movePlayer)
    {
        throw new NotImplementedException();
    }
}
