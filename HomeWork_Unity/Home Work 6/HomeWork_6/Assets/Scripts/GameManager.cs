using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pinText1;
    public TextMeshProUGUI pinText2;
    public TextMeshProUGUI pinText3;
    public TextMeshProUGUI winGameText;
    public TextMeshProUGUI winResultTimeGameText;
    public TextMeshProUGUI winResultNumberMovesText;


    public GameObject restartPanelGameObject;
    public GameObject handlerPanelGameObject;
    public TimeHandller timeHandller;

    private int _drill;
    private int _hammer;
    private int _skeletonKey;
    private float _winResultGame;
    private int _movesNumber = 0;
    private float _result;

    private void Start()
    {
        _drill = Random.Range(0, 11);
        _hammer = Random.Range(0, 11);
        _skeletonKey = Random.Range(0, 11);
        pinText1.text = _drill.ToString();
        pinText2.text = _hammer.ToString();
        pinText3.text = _skeletonKey.ToString();
    }
    private void Update()
    {
        _winResultGame = timeHandller.SaveCurrentTime();
    }


    // Интсрумент-дрель.
    public void OnClickButtonDrill()
    {
        _drill++;
        _hammer--;

        pinText1.text = _drill.ToString();
        pinText2.text = _hammer.ToString();
        pinText3.text = _skeletonKey.ToString();
        _movesNumber++;
        CheckendOnClickButtonTool();
    }


    // Интсрумент-молоток.
    public void OnClickButtonHammer()
    {
        _drill--;
        _hammer = _hammer + 2;
        _skeletonKey--;

        pinText1.text = _drill.ToString();
        pinText2.text = _hammer.ToString();
        pinText3.text = _skeletonKey.ToString();
        _movesNumber++;
        CheckendOnClickButtonTool();
    }


    // Интсрумент-отмычка.
    public void OnClickButtonSkeletonKey()
    {
        _drill--;
        _hammer++;
        _skeletonKey++;

        pinText1.text = _drill.ToString();
        pinText2.text = _hammer.ToString();
        pinText3.text = _skeletonKey.ToString();
        _movesNumber++;
        CheckendOnClickButtonTool();
    }

    // Все пины сошлись.
    private void CheckendOnClickButtonTool()
    {
        if (_drill == _hammer && _hammer == _skeletonKey && _drill == _skeletonKey)
        {
            handlerPanelGameObject.SetActive(false);
            restartPanelGameObject.SetActive(true);
            StopWinningGame();
        }
    }
    // Когда выиграл.
    public void StopWinningGame()
    {
        Time.timeScale = 0;
        winGameText.text = "Вы выйграли!";
    }

    // Результат игры(время и ходы).
    public void ResultTimeGame()
    {
        _result = 60 - _winResultGame;
        winResultTimeGameText.text = Mathf.Round(_result).ToString();
        winResultNumberMovesText.text = _movesNumber.ToString();
    }
}
