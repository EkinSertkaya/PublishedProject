using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponStatsText : MonoBehaviour
{
    [SerializeField] private PlayerWeapon playerWeapon;
    [SerializeField] private UpgradeType upgradeType;

    private TextMeshProUGUI weaponStatsText;

    void Start()
    {
        weaponStatsText = GetComponent<TextMeshProUGUI>();

        UpdateStats();

        playerWeapon.OnWeaponUpgrade += PlayerWeapon_OnWeaponUpgrade;
    }

    private void PlayerWeapon_OnWeaponUpgrade(object sender, System.EventArgs e)
    {
        if (playerWeapon.UpgradeType == upgradeType)
        {
            switch (playerWeapon.UpgradeType)
            {
                case UpgradeType.UpgradeRateOfFire:
                    weaponStatsText.text = "Rate Of Fire : " + (float)Mathf.Round(playerWeapon.RateOfFire * 100) / 100f ;
                    break;
                case UpgradeType.UpgradeVelocity:
                    weaponStatsText.text = "Velocity        : " + playerWeapon.BulletVelocity;
                    break;
                case UpgradeType.UpgradeTurnSpeed:
                    weaponStatsText.text = "Turn Speed   : " + playerWeapon.PlayerMovement.RotationSpeed;
                    break;
                case UpgradeType.AdditionalBarrel:
                    weaponStatsText.text = "Barrel           : " + playerWeapon.BarrelUpgradeLevel;
                    break;
            }
        }
    }

    private void UpdateStats()
    {
        switch (upgradeType)
        {
            case UpgradeType.UpgradeRateOfFire:
                weaponStatsText.text = "Rate Of Fire : " + playerWeapon.RateOfFire;
                break;
            case UpgradeType.UpgradeVelocity:
                weaponStatsText.text = "Velocity        : " + playerWeapon.BulletVelocity;
                break;
            case UpgradeType.UpgradeTurnSpeed:
                weaponStatsText.text = "Turn Speed   : " + playerWeapon.PlayerMovement.RotationSpeed;
                break;
            case UpgradeType.AdditionalBarrel:
                weaponStatsText.text = "Barrel           : " + playerWeapon.BarrelUpgradeLevel;
                break;
        }
    }
}
