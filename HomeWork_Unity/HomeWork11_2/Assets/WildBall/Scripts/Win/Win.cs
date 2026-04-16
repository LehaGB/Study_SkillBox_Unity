using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _loader.LoadLevelButtonClicked(1);
            Debug.Log("Win");
        }
    }
}
