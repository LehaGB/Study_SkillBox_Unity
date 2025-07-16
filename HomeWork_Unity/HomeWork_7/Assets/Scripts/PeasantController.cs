using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PeasantController : MonoBehaviour
{
    public GameManager gameManager;
    public Image peasantTimerImg;

    public TextMeshProUGUI resourcesPeasantText;  // количество крестьян.
    public TextMeshProUGUI peasantNotEnoughWheat;  // недостаточно пшеницы.
    public TextMeshProUGUI peasantTimerText;  // Отображение секунд создания крестьянина.

    public Button peasantButton;  // нанять крестьянина.

    public int peasantCount = 3;   // количество крестьян.
    public int wheatPerPeasant = 4;  // количество крестьян.
    public int peasantCost = 4; // стоимость найма крестьянина.
    public float peasantCreateTime = 3;  // время создания крестьянина.

    private float _peasantTimer = -2;  // время ожидания создания крестьянина.


    // Время найма крестьянина.
    public void CreatePeasantTime()
    {
       
        if (_peasantTimer > 0)
        {
            _peasantTimer -= Time.deltaTime;
            peasantTimerImg.fillAmount = _peasantTimer / peasantCreateTime;
            peasantTimerText.text = Mathf.Round(_peasantTimer).ToString();
        }
        else if (_peasantTimer > -1)
        {
            peasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            _peasantTimer = -2;
            peasantTimerText.text = " ";
        }
        UpdateText();
    }
    public void CreatePeasantButton()
    {
        if(gameManager.wheatCount >= peasantCost)
        {
            gameManager.wheatCount -= peasantCost;
            _peasantTimer = peasantCreateTime;
            peasantNotEnoughWheat.text = "Создается...";
            peasantButton.interactable = false;
        }
        else if(gameManager.wheatCount < peasantCost)
        {
            peasantNotEnoughWheat.text = "Недостаточно пшеницы";
            peasantButton.interactable = false;
        }
        StartCoroutine(CoroutinePeasantNewText());
        StartCoroutine(CoroutinePeasantTimer());
    }
    public void UpdateText()
    {
        resourcesPeasantText.text = peasantCount.ToString();
    }
    IEnumerator CoroutinePeasantNewText()
    {
        yield return new WaitForSeconds(1f);
        peasantNotEnoughWheat.text = " ";
    }
    IEnumerator CoroutinePeasantTimer()
    {
        yield return new WaitForSeconds(peasantCreateTime);
        peasantButton.interactable = true;
    }
}
