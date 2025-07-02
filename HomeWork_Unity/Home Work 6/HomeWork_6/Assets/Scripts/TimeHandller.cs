using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeHandller : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resulrGameText;
    public TextMeshProUGUI resultNumberGameText;
    public GameObject restartPanelGameObject;

    public float _curentTime = 60;  // ����� ����.
    public float _rsultCurentTime = 0;  // ����� ����.

    void Update()
    {
        CurrentTime();
        SaveCurrentTime();
    }

    
    // ����� ����.
    public void CurrentTime()
    {
        if(_curentTime > 0)
        {
            _curentTime -= Time.deltaTime;
            timerText.text = Mathf.Round(_curentTime).ToString();
        }
        else
        {
            _curentTime = 0;
            timerText.text = "����� �����";
            restartPanelGameObject.SetActive(true);
            StopLossGame();
        }
    }

    // ����� ��������.
    private void StopLossGame()
    {
        Time.timeScale = 0;
        resulrGameText.text = "�� ���������!";
    }
    public float SaveCurrentTime()
    {
        _rsultCurentTime = _curentTime;
        return _rsultCurentTime;
    }
}
