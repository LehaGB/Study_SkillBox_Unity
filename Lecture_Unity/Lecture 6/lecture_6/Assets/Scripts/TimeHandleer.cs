using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeHandleer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lapsText;
    public TextMeshProUGUI lapsTimeText;
    public TextMeshProUGUI previousLapsTimeText;

    private float currentTime;
    private float countLaps;
    private float currentLapsTime;
    private float previosLapsTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Mathf.Round(Time.time);
        
        timerText.text = currentTime.ToString();
    }
    public void LapsFinishedButtonClick()
    {
        CalculateRaceData();
        DisplayRaceData();
    }
    private void CalculateRaceData()
    {
        previosLapsTime = currentLapsTime;
        currentLapsTime = currentTime;
        countLaps = countLaps + 1;
    }
    private void DisplayRaceData()
    {
        lapsTimeText.text = currentLapsTime.ToString();
        previousLapsTimeText.text = previosLapsTime.ToString();
        lapsText.text = countLaps.ToString();
    }
}
