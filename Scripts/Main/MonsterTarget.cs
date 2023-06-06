using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTarget : MonoBehaviour
{
    public static event EventHandler OnMonsterPassed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Monster>(out Monster monster))
        {
            if(monster.CreatureType == CreatureType.Monster)
            {
                RulesManager.Instance.IncrementKilledMonsterAmount();
                OnMonsterPassed?.Invoke(this, EventArgs.Empty);
                collision.gameObject.SetActive(false);
            }
        }
    }
}
