using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private int damageAmount = 250;

    private Collider2D[] affectedColliders;

    private GameObject xPlosion;

    public void Detonate()
    {
        xPlosion = XplosionPool.Instance.GetFromXplosionPool();
        xPlosion.transform.position = transform.position;

        affectedColliders = Physics2D.OverlapCircleAll(transform.position, 1f);

        foreach(Collider2D colliders in affectedColliders)
        {
            colliders.TryGetComponent<HealthSystem>(out HealthSystem healthSystem);

            if (healthSystem)
            {
                healthSystem.ApplyDamage(damageAmount);
            }
        }

        gameObject.SetActive(false);
    }

    public void ActivateMine()
    {
        gameObject.SetActive(true);
    }
}
