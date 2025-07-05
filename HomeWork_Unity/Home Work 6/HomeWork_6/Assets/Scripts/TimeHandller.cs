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

    private float _resultTime;  // ��������� ������� ����.
    private int _resultNumberMoves;  // ��������� ����������� �����.
    private bool _gameIsOver = false;
    private float _curentTime = 60;  // ������� ����� ��� ����.
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

    #region ���� ����� �����������.
    // ���� ����� �����������.
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
            timerText.text = "����� �����";
            UpdateTimerText();
            StopLossGame();
        }
    }
    #endregion


    #region ������.
    // ������.
    private void UpdateTimerText()
    {
        timerText.text = Mathf.Round(_curentTime).ToString();
    }
    #endregion


    #region ����� ��������.
    // ����� ��������.
    private void StopLossGame()
    {
        _gameIsOver = true;
        Time.timeScale = 0;
        resulrGameText.text = "�� ���������!";
        handlerPanelGameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        restartPanelGameObject.SetActive(true);
        ActivateButtonResult();
    }
    #endregion


    #region ������� �������.
    // ������� �������.
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


    #region ����� �� �������.
    // ����� �� �������.
    public void OnClickButtonResult()
    {
        resultPanelGameObject.gameObject.SetActive(true);
        CurrentTime();
        ShowResults();
    }
    #endregion


    #region ��������� ������� � ����� ����.
    // ��������� ������� � ����� ����.
    private void ShowResults()
    {
        Debug.Log("���4");
        ActivateButtonResult();
        float time = ResultTimeGame();
        resulTimeGameText.text = Mathf.Round(time).ToString();
        int moves = gameManager.GetMovesNumber();
        resulMovesGameText.text = moves.ToString();
        Debug.Log("���5");
    }
    #endregion


    #region ���������� ������ ���������.
    // ���������� ������ ���������.
    public void ActivateButtonResult()
    {
         resultButton.gameObject.SetActive(true);
    }
    #endregion


    #region ���������� ������ � �����������.
    // ���������� ������ � �����������.
    public void ActivateResultPanel()
    {
        resultPanelGameObject.gameObject.SetActive(true);
    }
    #endregion
}
