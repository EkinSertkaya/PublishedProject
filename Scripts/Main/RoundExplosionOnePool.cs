using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundExplosionOnePool : MonoBehaviour
{
    public static RoundExplosionOnePool Instance { get; private set; }

    [SerializeField] private GameObject roundExplosionOne;

    private GameObject[] roundExplosionOnePool = new GameObject[5];

    [SerializeField] private BulletPool bulletPool;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        CreatePool();

        bulletPool.OnBulletSpecialUpgraded += BulletPool_OnBulletSpecialUpgraded;
    }

    private void BulletPool_OnBulletSpecialUpgraded(object sender, System.EventArgs e)
    {
        if(bulletPool.PlayerWeapon.BulletType.GetComponent<Bullet>().BulletType == BulletType.Rocket)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 radiusIncreaseAmount = new Vector3(0.2f, 0.2f, 0f);
                roundExplosionOnePool[i].transform.localScale += radiusIncreaseAmount;
            }
        }
    }

    private void CreatePool()
    {
        for (int i = 0; i < 5; i++)
        {
            roundExplosionOnePool[i] = Instantiate(roundExplosionOne, transform.position, Quaternion.identity, transform);
            roundExplosionOnePool[i].SetActive(false);
        }
    }

    public GameObject GetFromRoundExplosionOnePool()
    {
        for(int i = 0; i < roundExplosionOnePool.Length; i++)
        {
            if (!roundExplosionOnePool[i].activeSelf)
            {
                roundExplosionOnePool[i].SetActive(true);
                return roundExplosionOnePool[i];
            }
        }

        return null;
    }
}
