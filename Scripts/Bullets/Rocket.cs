using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    private int damageAmount = 50;
    public int DamageAmount { get { return damageAmount; } }

    private float damageRadius = 2f;
    public float DamageRadius { get { return damageRadius; } }

    private GameObject explosionOne;

    private bool exploded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!exploded && gameObject.activeSelf)
        {   
            exploded = true;
            explosionOne = RoundExplosionOnePool.Instance.GetFromRoundExplosionOnePool();
            explosionOne.transform.position = transform.position;
        }

        Collider2D[] hitMonsters = Physics2D.OverlapCircleAll(transform.position, damageRadius);

        foreach(Collider2D hitMonster in hitMonsters)
        {
            hitMonster.transform.TryGetComponent(out HealthSystem healthSystem);

            if (healthSystem)
            {
                healthSystem.ApplyDamage(damageAmount);
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
        damageRadius += 0.1f;
    }
}
