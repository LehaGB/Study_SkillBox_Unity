using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPlayersDeath
{
    public static event Action OnPlayerDied;
    bool DeathPlayer(GameObject player, GameObject ground);
}
