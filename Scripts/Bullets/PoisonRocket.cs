using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonRocket : Bullet
{
    private int damageAmount = 20;
    public int DamageAmount { get { return damageAmount; } }

    private int poisonDamage = 25;
    public int PoisonDamage { get { return poisonDamage; } }

    private GameObject explosionOne;

    private bool exploded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!exploded && gameObject.activeSelf)
        {
            exploded = true;
            explosionOne = RoundExplosionTwoPool.Instance.GetFromRoundExplosionTwoPool();
            explosionOne.transform.position = transform.position;
        }

        Collider2D[] hitMonsters = Physics2D.OverlapCircleAll(transform.position, 1.5f);

        foreach (Collider2D hitMonster in hitMonsters)
        {
            hitMonster.transform.TryGetComponent(out HealthSystem healthSystem);
            if (healthSystem)
            {
                healthSystem.ApplyDamage(damageAmount);
                healthSystem.Poison(poisonDamage);
            }
        }

        transform.localPosition = Vector3.zero;
        exploded = false;
        gameObject.SetActive(false);
    }

    public override void UpgradeBulletDamage()
    {
        damageAmount += 10;
    }

    public override void UpgradeBulletSpecial()
    {
        poisonDamage += 20;
    }
}
