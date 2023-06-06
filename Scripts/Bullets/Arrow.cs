using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bullet
{
    private int damageAmount = 100;
    public int DamageAmount { get { return damageAmount; } }

    private int stunChancePercentage = 0;
    public int StunChancePercentage { get { return stunChancePercentage; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent(out HealthSystem healthSystem);
        collision.gameObject.TryGetComponent(out MonsterMovement monsterMovement);

        if (healthSystem)
        {
            if (healthSystem.gameObject.CompareTag("SmallMonster") || healthSystem.gameObject.CompareTag("MediumMonster"))
            {
                healthSystem.ApplyDamage(healthSystem.MaxHealth);
            }
            else if(healthSystem.gameObject.CompareTag("BigMonster") || healthSystem.gameObject.CompareTag("BossMonster"))
            {
                if(Random.Range(1, 101) <= stunChancePercentage)
                {
                    monsterMovement.Stun(5f);
                }

                healthSystem.ApplyDamage(damageAmount);
            }
        }

        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    public override void UpgradeBulletDamage()
    {
        damageAmount += base.damageIncreaseAmount;
    }

    public override void UpgradeBulletSpecial()
    {
        stunChancePercentage += 3;
    }
}
