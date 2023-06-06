using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    [SerializeField] private PlayerWeapon playerWeapon;
    public PlayerWeapon PlayerWeapon { get { return playerWeapon; } }

    [SerializeField] private UpgradeType upgradeType;
    public UpgradeType UpgradeType { get { return upgradeType; } }

    [SerializeField] private GameObject maxInfoPanel;

    public void UpgradeWeapon()
    {
        switch (upgradeType)
        {
            case UpgradeType.UpgradeRateOfFire:
                playerWeapon.UpgradeRateOfFire();
                DisableOnMaxLevel(playerWeapon.RateOfFireLevel, playerWeapon.RateOfFireMaxLevel);
                break;
            case UpgradeType.UpgradeVelocity:
                playerWeapon.UpgradeVelocity();
                DisableOnMaxLevel(playerWeapon.VelocityLevel, playerWeapon.VelocityMaxLevel);
                break;
            case UpgradeType.AdditionalBarrel:
                playerWeapon.UpgradeBarrelNumber();
                DisableOnMaxLevel(playerWeapon.BarrelUpgradeLevel, playerWeapon.BarrelMaxUpgradeLevel);
                break;
            case UpgradeType.UpgradeTurnSpeed:
                playerWeapon.UpgradeTurnSpeed();
                DisableOnMaxLevel(playerWeapon.TurnSpeedLevel, playerWeapon.TurnSpeedMaxLevel);
                break;
        }
    }

    private void DisableOnMaxLevel(int currentUpgradeLevel, int maxUpgradeLevel)
    {
        if (currentUpgradeLevel >= maxUpgradeLevel)
        {
            gameObject.SetActive(false);
            maxInfoPanel.gameObject.SetActive(true);
        }
    }
}
