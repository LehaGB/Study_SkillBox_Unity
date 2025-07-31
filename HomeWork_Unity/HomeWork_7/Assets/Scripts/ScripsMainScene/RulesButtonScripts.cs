using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RulesButtonScripts : MonoBehaviour
{
    public GameObject gameObjectRulesPanel;
    public GameObject gameObjectMainPanel;
    public TextMeshProUGUI rulesText;

    private string rules = "Создавайте больше крестьян, чтоб увеличить добычи пшеницы," +
        "также не забывайте про атаку врагов, после каждого набега , количество врагов " +
        "увеличивается.Успехов вам!!!";

    private void Start()
    {
        rulesText.text = rules;
    }
    
    public void ButtonClickRules()
    {
        if(gameObject != null)
        {
            gameObjectRulesPanel.SetActive(true);
            gameObjectMainPanel.SetActive(false);
        }
        else
        {
            gameObjectRulesPanel.SetActive(false);
            gameObjectMainPanel.SetActive(true);
        }
    }
    public void ButtonClickRulesBack()
    {
        if (gameObject != null)
        {
            gameObjectRulesPanel.SetActive(false);
            gameObjectMainPanel.SetActive(true);
        }
        else
        {
            gameObjectRulesPanel.SetActive(true);
            gameObjectMainPanel.SetActive(false);
        }
    }
}
