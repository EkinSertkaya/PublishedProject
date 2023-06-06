using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentLevelText : MonoBehaviour
{
    private TextMeshProUGUI currentLevelText;

    private void Awake()
    {
        currentLevelText = GetComponent<TextMeshProUGUI>();

        RulesManager.Instance.OnLevelComplete += Instance_OnLevelComplete;

        currentLevelText.text = "Level: " + RulesManager.Instance.Level.ToString();
    }

    private void Instance_OnLevelComplete(object sender, System.EventArgs e)
    {
        currentLevelText.text = "Level: " + RulesManager.Instance.Level.ToString();
    }
}
