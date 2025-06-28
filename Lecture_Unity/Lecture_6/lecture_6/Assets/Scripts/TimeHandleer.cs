using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeHandleer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI completedCircleText;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Mathf.Round(7.7f));
        Debug.Log(Mathf.Round(1.4f));
        Debug.Log(Mathf.Round(5.5f));
        Debug.Log(Mathf.Round(6.5f));
        Debug.Log(Mathf.Round(-0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Mathf.Round(Time.time);
        completedCircleText.text = Mathf.Round((currentTime - 4) / 10).ToString();
        timerText.text = currentTime.ToString();

    }
}
