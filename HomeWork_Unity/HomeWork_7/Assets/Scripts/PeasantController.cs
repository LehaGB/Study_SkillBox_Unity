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
    
    public Button peasantButton;  // нанять крестьянина.

    public int peasantCount = 3;   // количество крестьян.
    public int wheatPerPeasant = 4;  // количество крестьян.
    public int peasantCost = 4; // стоимость найма крестьянина.
    public float peasantCreateTime = 3;  // время создания крестьянина.
    //public int wheatCount = 20;  // коичество пшеницы.

    private float _peasantTimer = -2;  // время ожидания создания крестьянина.

    public void CreatePeasantTime()
    {
       
        if (_peasantTimer > 0)
        {
            _peasantTimer -= Time.deltaTime;
            peasantTimerImg.fillAmount = _peasantTimer / peasantCreateTime;
        }
        else if (_peasantTimer > -1)
        {
            peasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            _peasantTimer = -2;
        }
        UpdateText();
    }
    public void CreatePeasantButton()
    {
        gameManager.wheatCount -= peasantCost;
        _peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;
    }
    public void UpdateText()
    {
        resourcesPeasantText.text = peasantCount.ToString();
    }
}
