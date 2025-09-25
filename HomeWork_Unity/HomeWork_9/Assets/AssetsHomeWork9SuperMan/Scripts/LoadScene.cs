using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadSceneHomeWork9 : MonoBehaviour
{

    public GameObject victoryPanel;
    public TextMeshProUGUI victoryText;

    void Start()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        playerController.LoadScene += Activate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        victoryPanel.SetActive(true);
        victoryText.text = "онаедю!!!";
        Time.timeScale = 0;
    }
}
