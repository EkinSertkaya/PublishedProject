using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPoint : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;

    public void Shoot()
    {
        GetBulletFromPool();
    }

    private void GetBulletFromPool()
    {
        foreach (GameObject pooledBullet in bulletPool.PooledBulletList)
        {
            if (!pooledBullet.activeSelf)
            {
                pooledBullet.transform.position = transform.position;
                pooledBullet.transform.rotation = transform.rotation;
                pooledBullet.SetActive(true);
                return;
            }
        }
    }
}
