using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PausedUIGame : MonoBehaviour
{
    public TextMeshProUGUI pauseText;
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public Button hintButton;

    public void PauseButtonGame()
    {
        if (gameIsPaused)
        {
            Resume();   
        }
        else
        {
            Pause();
        }
    }
    private void Resume()
    {
        pauseMenuUI.SetActive(true);  // ��������� ���� �����.
        Time.timeScale = 1f;            // ������������ �����.
        gameIsPaused = false;
        pauseText.text = "�����";
        hintButton.gameObject.SetActive(false);
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(false);  // �������� ���� �����.
        Time.timeScale = 0f;           // ������������� �����.
        gameIsPaused = true;
        pauseText.text = "�����������";
        hintButton.gameObject.SetActive(true);
    }
}
