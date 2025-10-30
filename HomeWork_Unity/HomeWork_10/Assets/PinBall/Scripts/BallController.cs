using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BallController : MonoBehaviour
{
    public TextMeshProUGUI countDummyText;
    private int countDummy = 0;

    public bool isActive = true;
    public Spawn spawn;

    public int CountDummy
    { 
        get => countDummy;
        set
        {
            countDummy = value;
            UpdateText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dummy"))
        {
            Destroy(other.gameObject);
            CountDummy++;
            spawn.CreateDummy();
        }
    }
    private void UpdateText()
    {
        countDummyText.text = $"{CountDummy}";
    }
}
