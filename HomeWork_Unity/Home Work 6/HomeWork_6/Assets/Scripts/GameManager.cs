using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pinText1;
    [SerializeField] private TextMeshProUGUI pinText2;
    [SerializeField] private TextMeshProUGUI pinText3;
    [SerializeField] private TextMeshProUGUI winGameText;
    [SerializeField] private TextMeshProUGUI winResultTimeGameText;
    [SerializeField] private TextMeshProUGUI winResultNumberMovesText;

    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resultButton;

    [SerializeField] private GameObject restartPanelGameObject;
    [SerializeField] private GameObject handlerPanelGameObject;
    [SerializeField] private TimeHandller timeHandller;

    private int _drill;             // �����.
    private int _hammer;            // �������.
    private int _skeletonKey;       // �������.
    private int _movesNumber = 0;  // ���������� �����.
    private float _resultMovesNumber;

    private const int MIN_PIN_VALUE = 0;  // ����������� �������� ����.
    private const int MAX_PIN_VALUE = 10;  // ������������ �������� ����.

    private void Start()
    {
        _drill = UnityEngine.Random.Range(MIN_PIN_VALUE, MAX_PIN_VALUE + 1);
        _hammer = UnityEngine.Random.Range(MIN_PIN_VALUE, MAX_PIN_VALUE + 1);
        _skeletonKey = UnityEngine.Random.Range(MIN_PIN_VALUE, MAX_PIN_VALUE + 1);
        Execute();
    }


    #region ������� ������ ����������
    public void Tools(int indexTools)
    {
        switch (indexTools)
        {
            case 0:
                OnClickButtonDrill();
                break;
            case 1:
                OnClickButtonHammer();
                break;
            case 2:
                OnClickButtonSkeletonKey();
                break;
            default:
                break;
        }
        IncrementMoves();
    }
    #endregion


    #region ����
    // ����
    public void Execute()
    {
        pinText1.text = _drill.ToString();
        pinText2.text = _hammer.ToString();
        pinText3.text = _skeletonKey.ToString();
    }
    #endregion


    #region ����������� �����.
    // ����������� �����.
    private int ClampPinValue(int value)
    {
        return Mathf.Clamp(value, MIN_PIN_VALUE, MAX_PIN_VALUE);
    }
    #endregion


    #region ����������-�����.
    // ����������-�����.
    public void OnClickButtonDrill()
    {
        _drill++;
        _drill = ClampPinValue(_drill);

        _hammer--;
        _hammer = ClampPinValue(_hammer);
        _skeletonKey = ClampPinValue(_skeletonKey);

        Execute();
        CheckendOnClickButtonTool();
    }
    #endregion


    #region ����������-�������.
    // ����������-�������.
    public void OnClickButtonHammer()
    {
        _drill--;
        _drill = ClampPinValue(_drill);

        _hammer = _hammer + 2;
        _hammer = ClampPinValue(_hammer);

        _skeletonKey--;
        _skeletonKey = ClampPinValue(_skeletonKey);

        Execute();
        CheckendOnClickButtonTool();
    }
    #endregion


    #region ����������-�������.
    // ����������-�������.
    public void OnClickButtonSkeletonKey()
    {
        _drill--;
        _drill = ClampPinValue(_drill);

        _hammer++;
        _hammer = ClampPinValue(_hammer);

        _skeletonKey++;
        _skeletonKey = ClampPinValue(_skeletonKey);

        Execute();
        CheckendOnClickButtonTool();
    }
    #endregion


    #region ��� ���� �������.
    // ��� ���� �������.
    private void CheckendOnClickButtonTool()
    {
        if (_drill == _hammer && _hammer == _skeletonKey)
        {
            handlerPanelGameObject.SetActive(false);
            restartPanelGameObject.SetActive(true);
            StopWinningGame();
        }
    }
    #endregion


    #region ����� �������.
    // ����� �������.
    public void StopWinningGame()
    {
        Time.timeScale = 0;
        winGameText.text = "�� ��������!";
        pauseButton.gameObject.SetActive(false);
        resultButton.gameObject.SetActive(true);
    }
    #endregion


    #region ���������� �����.
    // ���������� �����.
    private void IncrementMoves()
    {
        _movesNumber++;
    }
    #endregion


    #region ����� ��� ��������� ���������� ����� �� TimeHandller
    // ����� ��� ��������� ���������� ����� �� TimeHandller
    public int GetMovesNumber()
    {
        return _movesNumber;
    }
    #endregion
}
