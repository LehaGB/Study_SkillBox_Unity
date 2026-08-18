using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoinsPrefab : AbstractPrefabCreate
{
    [SerializeField] private GameObject coinPrefab;
    public override GameObject Prefab { get => coinPrefab; set => coinPrefab = value; }

    [SerializeField] private float _posXCoin = 2.3f;
    [SerializeField] private float _posZCoin = 20f;
    [SerializeField] private float _posZ2Coin = -9f;
    [SerializeField] private float _posYCoin = 0.1f;
    [SerializeField] private float _posY2Coin = 0.3f;
    [SerializeField] private int _countCoinMax = 10;
    [SerializeField] private int _countCoinMin = 5;


    public override GameObject CreatePrefab(Transform parent)
    {
        int randomCountCoin = Random.Range(_countCoinMin, _countCoinMax);
        GameObject firstCoin = null;

        for (int i = 0; i < randomCountCoin; i++)
        {
            float randomX = Random.Range(_posXCoin, -_posXCoin);
            float randomZ = Random.Range(_posZCoin, _posZ2Coin);
            float randomY = Random.Range(_posYCoin, _posY2Coin);

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            GameObject newCoin = GameObject.Instantiate(Prefab, parent);

            newCoin.transform.localPosition = spawnPosition;
            if(i  == 0)
            {
                firstCoin = newCoin;
            }
        }
        return firstCoin;
    }
}
