using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCreatePrefab : ICreatePrefab
{
    [Header("Coin Spawn Parameters")]
    public GameObject _coinPrefab;
    protected float _posXCoin = -1.5f;
    protected float _posX2Coin = 2.3f;
    protected float _posYCoin = 32f;
    protected float _posY2Coin = 3f;
    protected int _countCoinMax = 15;
    protected int _countCoinMin = 5;

    [Header("Player Spawn Parameters")]
    public GameObject _playerPrefab;
    protected float _posYPlayer = 0.12f;
    protected float _posZPlayer = -49f;

    public abstract void CreatePrefab(Transform parentTransform);
}
