using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerPrefab : AbstractCreatePrefab
{

    public GameObject CreatePlayer(Transform parentTransform)
    {
        Vector3 spawnPosPlayer = new Vector3(0, _posYPlayer, _posZPlayer);

        GameObject newPlayer = Object.Instantiate(_playerPrefab, spawnPosPlayer, Quaternion.identity);
        newPlayer.transform.SetParent(parentTransform);

        return newPlayer; 
    }

    public override void CreatePrefab(Transform parentTransform)
    {

        CreatePlayer(parentTransform);
    }
}
