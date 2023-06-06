using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    public event EventHandler OnMoneyChanged;

    public static PlayerEconomy Instance { get; private set; }

    private int playerMoney = 0;
    public int PlayerMoney { get { return playerMoney; } }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void RewardMoney(int amount)
    {
        playerMoney += amount;
        OnMoneyChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SpendMoney(int amount)
    {
        playerMoney -= amount;
        OnMoneyChanged?.Invoke(this, EventArgs.Empty);
    }
}
