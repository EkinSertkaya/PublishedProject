using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        PlayerEconomy.Instance.OnMoneyChanged += Instance_OnMoneyChanged;
        scoreText.text = PlayerEconomy.Instance.PlayerMoney.ToString();
    }

    private void Instance_OnMoneyChanged(object sender, System.EventArgs e)
    {
        scoreText.text = PlayerEconomy.Instance.PlayerMoney.ToString();
    }
}
