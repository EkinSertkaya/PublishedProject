using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Joystick joystick;

    [SerializeField] private TextMeshProUGUI monsterCounterText;

    private void Start()
    {
        RulesManager.Instance.OnLevelComplete += RulesManager_OnLevelComplete;
        RulesManager.Instance.OnDifficultySet += Instance_OnDifficultySet;
        MonsterTarget.OnMonsterPassed += MonsterTarget_OnMonsterPassed;
    }

    private void Instance_OnDifficultySet(object sender, System.EventArgs e)
    {
        if(RulesManager.Instance.ActiveDifficulty == DifficultyType.JustLetMePlay)
        {
            monsterCounterText.text = RulesManager.Instance.PassedMonsterAmount + "/" + "Infinite";
            return;
        }

        monsterCounterText.text = RulesManager.Instance.PassedMonsterAmount + "/" + RulesManager.Instance.PassedMonsterLimitForEnd.ToString();
    }

    private void MonsterTarget_OnMonsterPassed(object sender, System.EventArgs e)
    {
        if (RulesManager.Instance.ActiveDifficulty == DifficultyType.JustLetMePlay)
        {
            monsterCounterText.text = RulesManager.Instance.PassedMonsterAmount + "/" + "Infinite";
            return;
        }

        monsterCounterText.text = RulesManager.Instance.PassedMonsterAmount + "/" + RulesManager.Instance.PassedMonsterLimitForEnd.ToString();
    }

    private void RulesManager_OnLevelComplete(object sender, System.EventArgs e)
    {
        ShowHideShopUI();
    }

    public void ShowHideShopUI()
    {
        gameObject.SetActive(false);
        shopUI.SetActive(!shopUI.activeSelf);
    }
}
