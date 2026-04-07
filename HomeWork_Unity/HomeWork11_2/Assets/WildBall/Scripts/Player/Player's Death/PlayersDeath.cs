using System;
using UnityEngine;

public class PlayersDeath : MonoBehaviour, IPlayersDeath
{

    public GameObject playerPrefab;
    public GameObject groundPrefab;
    private void Update()
    {
        DeathPlayer(playerPrefab, groundPrefab);
    }
    public bool DeathPlayer(GameObject objectPlayer, GameObject objectGround)
    {
        if (objectPlayer.transform.position.y < objectGround.transform.position.y)
        {
            CheckCondition();
            return true;
        }
       return false;
    }
    public void CheckCondition()
    {
        EventsBus.Instance.TriggerPlayerDied();
        enabled = false;
    }
}
