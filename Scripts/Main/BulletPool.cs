using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public event EventHandler OnBulletDamageUpgraded;
    public event EventHandler OnBulletSpecialUpgraded;
    public event EventHandler OnBulletTypeChanged;

    [SerializeField] private PlayerWeapon playerWeapon;
    public PlayerWeapon PlayerWeapon { get { return playerWeapon; } }

    private List<GameObject> pooledBulletList = new List<GameObject>();
    public List<GameObject> PooledBulletList { get { return pooledBulletList; } }

    private int bulletDamageUpgradeCost = 100;
    public int BulletDamageUpgradeCost { get { return bulletDamageUpgradeCost; } }

    private int bulletSpecialUpgradeCost = 100;
    public int BulletSpecialUpgradeCost { get { return bulletSpecialUpgradeCost; } }

    private int bulletDamageLevel = 0;
    public int BulletDamageLevel { get { return bulletDamageLevel; } }

    private int bulletDamageMaxLevel = 10;
    public int BulletDamageMaxLevel { get { return bulletDamageMaxLevel; } }

    private int bulletSpecialLevel = 0;
    public int BulletSpecialLevel { get { return bulletSpecialLevel; } }

    private int bulletSpecialMaxLevel = 10;
    public int BulletSpecialMaxLevel { get { return bulletSpecialMaxLevel; } }

    private void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            GameObject createdBullet = Instantiate(playerWeapon.Bullet, transform.position, Quaternion.identity);
            createdBullet.GetComponent<Bullet>().PlayerWeapon = this.playerWeapon;
            createdBullet.transform.SetParent(transform);
            pooledBulletList.Add(createdBullet);
            createdBullet.SetActive(false);
        }

        playerWeapon.OnBulletTypeChanged += PlayerWeapon_OnBulletTypeChanged;
    }

    private void PlayerWeapon_OnBulletTypeChanged(object sender, System.EventArgs e)
    {
        for(int i = 0; i < 50; i++)
        {
            Destroy(pooledBulletList[i]);

            pooledBulletList[i] = Instantiate(playerWeapon.BulletType, gameObject.transform.position ,Quaternion.identity);
            pooledBulletList[i].GetComponent<Bullet>().PlayerWeapon = this.playerWeapon;
            pooledBulletList[i].SetActive(false);
        }

        for(int i = 0; i < bulletDamageLevel; i++)
        {
            UpgradePooledBulletDamage(true);
        }

        for(int i = 0; i < bulletSpecialLevel; i++)
        {
            UpgradePooledBulletSpecial(true);
        }

        OnBulletTypeChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UpgradePooledBulletDamage(bool isBulletChanged = false)
    {
        if (isBulletChanged)
        {
            for (int i = 0; i < 50; i++)
            {
                pooledBulletList[i].GetComponent<Bullet>().UpgradeBulletDamage();
            }

            OnBulletDamageUpgraded?.Invoke(this, EventArgs.Empty);
        }
        else if (!isBulletChanged)
        {
            if (bulletDamageLevel < 10)
            {
                if(PlayerEconomy.Instance.PlayerMoney >= bulletDamageUpgradeCost)
                {
                    PlayerEconomy.Instance.SpendMoney(bulletDamageUpgradeCost);
                    bulletDamageUpgradeCost += 500;
                    bulletDamageLevel++;

                    for (int i = 0; i < 50; i++)
                    {
                        pooledBulletList[i].GetComponent<Bullet>().UpgradeBulletDamage();
                    }

                    OnBulletDamageUpgraded?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    public void UpgradePooledBulletSpecial(bool isBulletChanged = false)
    {
        if (isBulletChanged)
        {
            for (int i = 0; i < 50; i++)
            {
                pooledBulletList[i].GetComponent<Bullet>().UpgradeBulletSpecial();
            }

            OnBulletSpecialUpgraded?.Invoke(this, EventArgs.Empty);
        }
        else if (!isBulletChanged)
        {
            if (bulletSpecialLevel < 10)
            {
                if (PlayerEconomy.Instance.PlayerMoney >= bulletSpecialUpgradeCost)
                {
                    PlayerEconomy.Instance.SpendMoney(bulletSpecialUpgradeCost);
                    bulletSpecialUpgradeCost += 300;
                    bulletSpecialLevel++;

                    for (int i = 0; i < 50; i++)
                    {
                        pooledBulletList[i].GetComponent<Bullet>().UpgradeBulletSpecial();
                    }

                    OnBulletSpecialUpgraded?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
