using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUpgradeLevelText : MonoBehaviour
{
    private TextMeshProUGUI weaponUpgradeLevelText;

    [SerializeField] private PlayerWeapon playerWeapon;

    [SerializeField] private UpgradeType upgradeType;

    private void Start()
    {
        weaponUpgradeLevelText = GetComponent<TextMeshProUGUI>();

        playerWeapon.OnWeaponUpgrade += PlayerWeapon_OnWeaponUpgrade;

        UpdateWeaponUpgradeLevelText();
    }

    private void PlayerWeapon_OnWeaponUpgrade(object sender, System.EventArgs e)
    {
        if(playerWeapon.UpgradeType == upgradeType)
        {
            UpdateWeaponUpgradeLevelText();
        }
    }

    private void UpdateWeaponUpgradeLevelText()
    {
        switch (upgradeType)
        {
            case UpgradeType.UpgradeRateOfFire:
                weaponUpgradeLevelText.text = ": Level " + playerWeapon.RateOfFireLevel.ToString();
                break;
            case UpgradeType.UpgradeVelocity:
                weaponUpgradeLevelText.text = ": Level " + playerWeapon.VelocityLevel.ToString();
                break;
            case UpgradeType.AdditionalBarrel:
                weaponUpgradeLevelText.text = ": Level " + playerWeapon.BarrelUpgradeLevel.ToString();
                break;
            case UpgradeType.UpgradeTurnSpeed:
                weaponUpgradeLevelText.text = ": Level " + playerWeapon.TurnSpeedLevel.ToString();
                break;
        }
    }
}
