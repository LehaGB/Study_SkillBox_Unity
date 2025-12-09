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
            float randomX = Random.Range(_posXCoin, _posX2Coin);
            float randomY = Random.Range(_posYCoin, _posY2Coin);

            Vector3 spawnPosition = new Vector3(randomX, 0.1f, randomY);

            GameObject newCoin = Object.Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);

            newCoin.transform.SetParent(parentTransform);
        }
    }
}
