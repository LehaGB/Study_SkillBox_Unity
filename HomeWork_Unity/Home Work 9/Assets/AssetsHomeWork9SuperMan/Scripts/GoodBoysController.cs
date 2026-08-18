using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GoodBoysController : MonoBehaviour
{
    public event Action OnEnemyDestroyed;

    public bool isDestroy = false;
    public int CountBadGuy { get { return _countBadGuy; } }

    private int _countBadGuy = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isDestroy = true;
            Destroy(collision.gameObject);
            _countBadGuy++;
            OnEnemyDestroyed?.Invoke();
            Debug.Log("YES");
        }

    }
    private void LateUpdate()
    {
        isDestroy = false;
    }
}
