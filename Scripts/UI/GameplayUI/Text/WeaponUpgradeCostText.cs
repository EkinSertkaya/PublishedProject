using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUpgradeCostText : MonoBehaviour
{
    private PlayerWeapon playerWeapon;

    private UpgradeType upgradeType;

    private TextMeshProUGUI upgradeCostText;

    private void Awake()
    {
        playerWeapon = GetComponentInParent<WeaponUpgrade>().PlayerWeapon;

        upgradeType = GetComponentInParent<WeaponUpgrade>().UpgradeType;

        upgradeCostText = GetComponent<TextMeshProUGUI>();

        UpgradeCost();
    }

    private void Start()
    {
        playerWeapon.OnWeaponUpgrade += PlayerWeapon_OnWeaponUpgrade;
    }

    private void PlayerWeapon_OnWeaponUpgrade(object sender, System.EventArgs e)
    {
        UpgradeCost();
    }

    private void UpgradeCost()
    {
        switch (upgradeType)
        {
            case UpgradeType.UpgradeRateOfFire:
                upgradeCostText.text = playerWeapon.RateOfFireUpgradeCost.ToString();
                break;
            case UpgradeType.UpgradeVelocity:
                upgradeCostText.text = playerWeapon.VelocityUpgradeCost.ToString();
                break;
            case UpgradeType.AdditionalBarrel:
                upgradeCostText.text = playerWeapon.BarrelUpgareCost.ToString();
                break;
            case UpgradeType.UpgradeTurnSpeed:
                upgradeCostText.text = playerWeapon.TurnSpeedUpgradeCost.ToString();
                break;
        }
    }
}
