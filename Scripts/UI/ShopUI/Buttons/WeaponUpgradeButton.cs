using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeButton : MonoBehaviour
{
    private WeaponUpgrade weaponUpgrade;

    private Button upgradeButton;

    [TextArea(10, 10)]
    [SerializeField] private string purchasingExplanationText;

    private int cost = 0;

    void Start()
    {
        weaponUpgrade = GetComponent<WeaponUpgrade>();

        upgradeButton = GetComponent<Button>();

        upgradeButton.onClick.AddListener(UpgradeConfirmation);
    }

    private void UpgradeConfirmation()
    {
        switch (weaponUpgrade.UpgradeType)
        {
            case UpgradeType.UpgradeRateOfFire:
                cost = weaponUpgrade.PlayerWeapon.RateOfFireUpgradeCost;
                break;
            case UpgradeType.UpgradeVelocity:
                cost = weaponUpgrade.PlayerWeapon.VelocityUpgradeCost;
                break;
            case UpgradeType.AdditionalBarrel:
                cost = weaponUpgrade.PlayerWeapon.BarrelUpgareCost;
                break;
            case UpgradeType.UpgradeTurnSpeed:
                cost = weaponUpgrade.PlayerWeapon.TurnSpeedUpgradeCost;
                break;
        }

        ConfirmationUI.Instance.PopConfirmationWindow(weaponUpgrade.UpgradeWeapon, purchasingExplanationText, cost);
    }
}
