using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterReward : MonoBehaviour
{
    [SerializeField] private int monsterReward;

    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        healthSystem.OnZeroCurrentHealth += HealthSystem_OnZeroCurrentHealth;
    }

    private void HealthSystem_OnZeroCurrentHealth(object sender, System.EventArgs e)
    {
        RulesManager.Instance.IncrementKilledMonsterAmount();
        PlayerEconomy.Instance.RewardMoney(monsterReward);
    }
}
