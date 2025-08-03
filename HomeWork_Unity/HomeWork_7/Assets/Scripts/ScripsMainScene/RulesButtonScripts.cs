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
        "увеличивается.Смотрите внимательно за количеством пшеницы, чтоб нанять крестьянина " +
        "необходимо 4 еденицы пшеницы, а воина 6 едениц и не нажимайте попросту кнопки " +
        "создания юнитов, так как для активирования кнопок потребуется некоторое время, что " +
        "зря потратите это время, лучше подождать один цикл сбора урожая, так как, чем больше " +
        "нанятых крестьян, тем больше пшеницы, за каждый цикл сбора урожая.Во время всей игры, " +
        "производятся специальные звуки, для большего понимания, звуки: сбор урожая, трата " +
        "за содержания воина, когда юнит создался, отдельный звуковой сигнал даст вам понять " +
        "что идет наступление врагов и индекатор поменяет цвет.Пробуйте создать 2000 едениц" +
        " пшеницы или 70 крестьян, чтобы одержать победу на врагом!" +
        "Удачи вам и хорошего провождение времени!!!";

    private void Start()
    {
        rulesText.text = rules;
    }


    // Нажали на кнопку Правила.
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


    // // Нажали на кнопку в меню правила назад.
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
