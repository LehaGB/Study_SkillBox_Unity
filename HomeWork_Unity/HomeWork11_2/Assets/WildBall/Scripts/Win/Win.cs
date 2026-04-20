using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;
    [SerializeField] private OutputScreen _outputScreen;
    [SerializeField] private bool isTrigger;
    private void OnTriggerEnter(Collider other)
    {
        isTrigger = false;
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            _outputScreen.ScreenText();
            Debug.Log("Win");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
            _outputScreen.ScreenExitText();
        }
    }


    private void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _loader.LoadLevelButtonClicked(1);
            }           
        }
    }
}
