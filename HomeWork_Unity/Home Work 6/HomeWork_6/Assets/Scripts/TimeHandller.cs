using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeHandller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI resulrGameText;
    [SerializeField] private TextMeshProUGUI resulTimeGameText;
    [SerializeField] private TextMeshProUGUI resulMovesGameText;
    [SerializeField] private GameObject restartPanelGameObject;
    [SerializeField] private GameObject resultPanelGameObject;
    [SerializeField] private GameObject handlerPanelGameObject;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resultButton;

    [SerializeField] private GameManager gameManager;

    private float _resultTime;  // результат времени игры.
    private int _resultNumberMoves;  // результат потраченных ходов.
    private bool _gameIsOver = false;
    private float _curentTime = 60;  // текущее время для игры.
    private int _maxTime = 60;

    private void Start()
    {
        UpdateTimerText();
    }

    void Update()
    {
        if (!_gameIsOver)
        {
            CurrentTime();
        }
    }

    #region Если время закончилось.
    // Если время закончилось.
    public void CurrentTime()
    {
        if(_curentTime > 0)
        {
            _curentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            _curentTime = 0;
            timerText.text = "Время вышло";
            UpdateTimerText();
            StopLossGame();
        }
    }
    #endregion


    #region Таймер.
    // Таймер.
    private void UpdateTimerText()
    {
        timerText.text = Mathf.Round(_curentTime).ToString();
    }
    #endregion


    #region Когда проиграл.
    // Когда проиграл.
    private void StopLossGame()
    {
        _gameIsOver = true;
        Time.timeScale = 0;
        resulrGameText.text = "Вы проиграли!";
        handlerPanelGameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        restartPanelGameObject.SetActive(true);
        ActivateButtonResult();
    }
    #endregion


    #region Подсчет времени.
    // Подсчет времени.
    public float ResultTimeGame()
    {
        if(!_gameIsOver && _curentTime > 0)
        {
            _resultTime = _maxTime - _curentTime;  
        }
        else
        {
            _resultTime = _curentTime;
        }
        return _resultTime;
    }
    #endregion


    #region Вызов по нажатию.
    // Вызов по нажатию.
    public void OnClickButtonResult()
    {
        resultPanelGameObject.gameObject.SetActive(true);
        CurrentTime();
        ShowResults();
    }
    #endregion


    #region Результат времени и ходов игры.
    // Результат времени и ходов игры.
    private void ShowResults()
    {
        Debug.Log("Нет4");
        ActivateButtonResult();
        float time = ResultTimeGame();
        resulTimeGameText.text = Mathf.Round(time).ToString();
        int moves = gameManager.GetMovesNumber();
        resulMovesGameText.text = moves.ToString();
        Debug.Log("Нет5");
    }
    #endregion


    #region Активируем кнопку результат.
    // Активируем кнопку результат.
    public void ActivateButtonResult()
    {
         resultButton.gameObject.SetActive(true);
    }
    #endregion


    #region Активируем панель с результатом.
    // Активируем панель с результатом.
    public void ActivateResultPanel()
    {
        resultPanelGameObject.gameObject.SetActive(true);
    }
    #endregion
}
