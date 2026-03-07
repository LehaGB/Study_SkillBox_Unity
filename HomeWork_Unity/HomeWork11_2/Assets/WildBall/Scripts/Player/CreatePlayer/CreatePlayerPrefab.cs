using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public sealed class CreatePlayerPrefab : AbstractCreatePrefab
{

    private GameObject _playerPrefab;

    public override GameObject Prefab { get => _playerPrefab; set => _playerPrefab = value; }

    public override GameObject CreatePrefab(Transform parentPlayer)
    {
        Vector3 startPosPlayer = new Vector3(0f, 0.5f, -4.0f);
        GameObject newPlayer  = GameObject.Instantiate(Prefab, startPosPlayer, Quaternion.identity, parentPlayer);
        return newPlayer;
    }
}
