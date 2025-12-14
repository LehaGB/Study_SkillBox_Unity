using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCreatePrefab : ICreatePrefab
{
    [Header("Coin Spawn Parameters")]
    public GameObject _coinPrefab;
    protected float _posXCoin = 2.3f;
    //protected float _posX2Coin = 2.3f;
    protected float _posZCoin = -45f;
    protected float _posZ2Coin = -9f;
    protected int _countCoinMax = 10;
    protected int _countCoinMin = 5;

    [Header("Player Spawn Parameters")]
    public GameObject _playerPrefab;
    public float _posYPlayer = 0.12f;
    public float _posZPlayer = -49f;

    public abstract void CreatePrefab(Transform parentTransform);
}
