using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoins : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private float _posX = -1.5f;
    private float _posX2 = 2.3f;
    private float _posY = 42f;
    private float _posY2 = 3f;
    private int _countCoinMax = 15;
    private int _countCoinMin = 5;

    private void Start()
    {
        RandomCreateCoins();
    }


    public void RandomCreateCoins()
    {
        int randomCountCoint = Random.Range(_countCoinMin, _countCoinMax);

        for (int i = 0; i < randomCountCoint; i++)
        {
            float randomX = Random.Range(_posX, _posX2);
            float randomY = Random.Range(_posY, _posY2);

            Vector3 spawnPosition = transform.position + new Vector3(randomX, 0.1f, randomY);

            GameObject newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            newCoin.transform.SetParent(transform);
        } 
    }
}
