    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public event EventHandler OnBulletTypeChanged;

    public event EventHandler OnWeaponUpgrade;

    [SerializeField] private GameObject bulletType;
    public GameObject BulletType { get { return bulletType; } }

    [SerializeField] private GameObject barrelOne;
    [SerializeField] private GameObject barrelTwo;

    private PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement { get { return playerMovement; } }

    private int barrelUpgradeLevel = 1;
    public int BarrelUpgradeLevel { get { return barrelUpgradeLevel; } }

    private int barrelMaxUpgradeLevel = 3;
    public int BarrelMaxUpgradeLevel { get { return barrelMaxUpgradeLevel; } }

    private int rateOfFireMultiplier = 2;
    public int RateOfFireMultiplier { get { return rateOfFireMultiplier; } }

    private float rateOfFireModifier = 0;

    public GameObject Bullet { get { return bulletType; } }

    private int rateOfFireLevel = 0;
    public int RateOfFireLevel { get { return rateOfFireLevel; } }

    private int rateOfFirMaxLevel = 5;
    public int RateOfFireMaxLevel { get { return rateOfFirMaxLevel; } }

    private float rateOfFire = 1f;
    public float RateOfFire { get { return rateOfFire; } }

    private int velocityLevel = 0;
    public int VelocityLevel { get { return velocityLevel; } }
    
    private int velocityMaxLevel = 5;
    public int VelocityMaxLevel { get { return velocityMaxLevel; } }

    private float bulletVelocity = 10f;
    public float BulletVelocity { get { return bulletVelocity; } }

    private int rateOfFireUpgradeCost = 100;
    public int RateOfFireUpgradeCost { get { return rateOfFireUpgradeCost; } }

    private int velocityUpgradeCost = 100;
    public int VelocityUpgradeCost { get { return velocityUpgradeCost; } }

    private int barrelUpgareCost = 5000;
    public int BarrelUpgareCost { get { return barrelUpgareCost; } }

    private int turnSpeedLevel = 0;
    public int TurnSpeedLevel { get { return turnSpeedLevel; } }

    private int turnSpeedMaxLevel = 5;
    public int TurnSpeedMaxLevel { get { return turnSpeedMaxLevel; } }

    private int turnSpeedUpgradeCost = 100;
    public int TurnSpeedUpgradeCost { get { return turnSpeedUpgradeCost; } }

    private UpgradeType upgradeType;
    public UpgradeType UpgradeType { get { return upgradeType; } }

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public void UpgradeRateOfFire()
    {
        if (PlayerEconomy.Instance.PlayerMoney >= rateOfFireUpgradeCost)
        {
            if (rateOfFireLevel < 5)
            {
                rateOfFire -= 0.1f;
                PlayerEconomy.Instance.SpendMoney(rateOfFireUpgradeCost);
                rateOfFireUpgradeCost += 200;
                rateOfFireLevel++;

                upgradeType = UpgradeType.UpgradeRateOfFire;

                OnWeaponUpgrade?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void UpgradeVelocity()
    {
        if (bulletVelocity < 25f)
        {
            if(PlayerEconomy.Instance.PlayerMoney >= velocityUpgradeCost)
            {
                bulletVelocity += 3f;
                PlayerEconomy.Instance.SpendMoney(velocityUpgradeCost);
                velocityUpgradeCost += 200;

                velocityLevel++;

                upgradeType = UpgradeType.UpgradeVelocity;

                OnWeaponUpgrade?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void UpgradeBarrelNumber()
    {
        if(PlayerEconomy.Instance.PlayerMoney >= barrelUpgareCost)
        {
            barrelUpgradeLevel++;

            if (barrelUpgradeLevel > 3)
            {
                barrelUpgradeLevel = 3;
            }

            if (barrelUpgradeLevel == 2)
            {
                barrelOne.gameObject.SetActive(true);
            }
            else if (barrelUpgradeLevel == 3)
            {
                barrelTwo.gameObject.SetActive(true);
                rateOfFireMultiplier = 3;
            }

            PlayerEconomy.Instance.SpendMoney(barrelUpgareCost);
            barrelUpgareCost *= 3;

            upgradeType = UpgradeType.AdditionalBarrel;

            OnWeaponUpgrade?.Invoke(this, EventArgs.Empty);
        }
    }

    public void UpgradeTurnSpeed()
    {
        if(turnSpeedLevel < 5)
        {
            if(PlayerEconomy.Instance.PlayerMoney >= turnSpeedUpgradeCost)
            {
                playerMovement.UpgradeTurnSpeed();

                PlayerEconomy.Instance.SpendMoney(turnSpeedUpgradeCost);
                turnSpeedUpgradeCost += 200;

                turnSpeedLevel++;

                upgradeType = UpgradeType.UpgradeTurnSpeed;

                OnWeaponUpgrade?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void SetBulletType(GameObject bulletType)
    {
        int bulletCost = bulletType.GetComponent<Bullet>().Cost;

        if (PlayerEconomy.Instance.PlayerMoney >= bulletCost)
        {
            PlayerEconomy.Instance.SpendMoney(bulletCost);

            this.bulletType = bulletType;

            BulletType currentBulletType = bulletType.GetComponent<Bullet>().BulletType;

            switch (currentBulletType)
            {
                case global::BulletType.SmallBullet:
                    SetRateOfFireModifier();
                    break;
                case global::BulletType.PoisonBullet:
                    SetRateOfFireModifier(1.5f);
                    break;
                case global::BulletType.Arrow:
                    SetRateOfFireModifier(2.3f);
                    break;
                case global::BulletType.PoisonRocket:
                    SetRateOfFireModifier(6f);
                    break;
                case global::BulletType.Rocket:
                    SetRateOfFireModifier(2f);
                    break;
                case global::BulletType.TimedExplosive:
                    SetRateOfFireModifier(3f);
                    break;
            }

            OnBulletTypeChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void SetRateOfFireModifier(float modifierAmount = 0f)
    {
        rateOfFire -= rateOfFireModifier;
        rateOfFireModifier = modifierAmount;
        rateOfFire += rateOfFireModifier;

        upgradeType = UpgradeType.UpgradeRateOfFire;

        OnWeaponUpgrade?.Invoke(this, EventArgs.Empty);
    }

    public void ResetWeaponRotation()
    {
        playerMovement.ResetWeaponRotation();
    }
}
