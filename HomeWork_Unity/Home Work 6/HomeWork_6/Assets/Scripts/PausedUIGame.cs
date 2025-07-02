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
        pauseMenuUI.SetActive(true);  // Отключаем меню паузы.
        Time.timeScale = 1f;            // Возобновляем время.
        gameIsPaused = false;
        pauseText.text = "Пауза";
        hintButton.gameObject.SetActive(false);
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(false);  // Включаем меню паузы.
        Time.timeScale = 0f;           // Останавливаем время.
        gameIsPaused = true;
        pauseText.text = "Возобновить";
        hintButton.gameObject.SetActive(true);
    }
}
