using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : Bullet
{
    private int damageAmount = 10;
    public int DamageAmount { get { return damageAmount; } }

    private int poisonDamage = 25;
    public int PoisonDamage { get { return poisonDamage; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            collision.gameObject.TryGetComponent(out HealthSystem healthSystem);
            if (healthSystem)
            {
                healthSystem.ApplyDamage(damageAmount);
                healthSystem.Poison(poisonDamage);
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
        poisonDamage += 25;
    }
}
