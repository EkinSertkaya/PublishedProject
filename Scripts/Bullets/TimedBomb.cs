using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedBomb : Bullet
{
    private int damageAmount = 50;
    public int DamageAmount { get { return damageAmount; } }

    private float detonateTime = 5f;
    public float DetonateTime { get { return detonateTime; } }

    private float detonateTimer = 0f;

    private GameObject xPlosion;

    private void Update()
    {
        detonateTimer += Time.deltaTime;

        if(detonateTimer >= detonateTime)
        {
            xPlosion = XplosionPool.Instance.GetFromXplosionPool();
            xPlosion.transform.position = transform.position;

            Collider2D[] hitMonsters = Physics2D.OverlapCircleAll(transform.position, 3f);

            foreach (Collider2D hitMonster in hitMonsters)
            {
                hitMonster.transform.TryGetComponent(out HealthSystem healthSystem);
                if (healthSystem)
                {
                    healthSystem.ApplyDamage(damageAmount);
                }
            }

            detonateTimer -= detonateTimer;
            transform.localPosition = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    public override void UpgradeBulletDamage()
    {
        damageAmount += 25;
    }

    public override void UpgradeBulletSpecial()
    {
        detonateTime -= 0.2f;
    }
}
