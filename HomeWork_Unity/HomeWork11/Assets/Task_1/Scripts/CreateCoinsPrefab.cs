using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoinsPrefab : AbstractCreatePrefab
{
    public override void CreatePrefab(Transform parentTransform)
    {
        int randomCountCoin = Random.Range(_countCoinMin, _countCoinMax);

        for (int i = 0; i < randomCountCoin; i++)
        {
            float randomX = Random.Range(_posXCoin, -_posXCoin);
            float randomZ = Random.Range(_posZCoin, _posZ2Coin);
            float randomY = Random.Range(_posYCoin, _posY2Coin);

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            GameObject newCoin = Object.Instantiate(_coinPrefab, parentTransform);

            newCoin.transform.localPosition = spawnPosition;
        }
    }
}
