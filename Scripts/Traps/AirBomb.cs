using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBomb : MonoBehaviour
{
    private int damage = 1000;

    private Vector3 cachedLocalPos;

    private Collider2D[] targets;

    private GameObject xPlosion;

    private void Start()
    {
        cachedLocalPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        xPlosion = XplosionPool.Instance.GetFromXplosionPool();
        xPlosion.transform.position = transform.position;

        targets = Physics2D.OverlapCircleAll(transform.position, 3f);

        foreach(Collider2D targetColliders in targets)
        {
            targetColliders.gameObject.TryGetComponent<HealthSystem>(out HealthSystem healthSystem);

            if (healthSystem)
            {
                healthSystem.ApplyDamage(damage);
            }
        }

        transform.position = cachedLocalPos;
        gameObject.SetActive(false);
    }
}
