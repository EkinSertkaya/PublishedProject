using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : Bullet
{
    private Collider2D[] collidersArray;

    private GameObject verticalExplosion;

    private bool exploded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!exploded && gameObject.activeSelf)
        {
            exploded = true;
            verticalExplosion = VerticalExplosionPool.Instance.GetFromVerticalExplosionPool();
            verticalExplosion.transform.position = transform.position;
        }

        collidersArray = Physics2D.OverlapCircleAll(transform.position, 4f);

        foreach(Collider2D colliders in collidersArray)
        {
            colliders.TryGetComponent<HealthSystem>(out HealthSystem healthSystem);

            if (healthSystem)
            {
                healthSystem.ApplyDamage(healthSystem.MaxHealth);
            }
        }

        exploded = false;
        gameObject.SetActive(false);
    }

    public override void UpgradeBulletDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void UpgradeBulletSpecial()
    {
        throw new System.NotImplementedException();
    }
}
