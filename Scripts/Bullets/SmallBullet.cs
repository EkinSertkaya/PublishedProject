using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBullet : Bullet
{
    private int damageAmount = 10;
    public int DamageAmount { get { return damageAmount; } }

    private int criticalChance = 0;
    public int CriticalChance { get { return criticalChance; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            collision.gameObject.TryGetComponent(out HealthSystem healthSystem);
            if (healthSystem)
            {
                if((int)Random.Range(1f, 100f) <= criticalChance)
                {
                    healthSystem.ApplyDamage(damageAmount * 2);
                }
                else
                {
                    healthSystem.ApplyDamage(damageAmount);
                }
            }

        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    public override void UpgradeBulletDamage()
    {
        damageAmount += 10;
    }

    public override void UpgradeBulletSpecial()
    {
        criticalChance += 2;
    }
}