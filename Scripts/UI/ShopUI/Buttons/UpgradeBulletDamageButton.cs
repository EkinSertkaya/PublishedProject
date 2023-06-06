using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBulletDamageButton : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    public BulletPool BulletPool { get { return bulletPool; } }

    private Button bulletDamageUpgradeButton;

    [SerializeField] private GameObject maxInfoPanel;

    [TextArea(10, 10)]
    [SerializeField] private string purchasingExplanationText;

    private string purchasingExplanationTextWithDamageAmount;

    private void Start()
    {
        bulletDamageUpgradeButton = GetComponent<Button>();

        purchasingExplanationTextWithDamageAmount = purchasingExplanationText + " " + bulletPool.PlayerWeapon.BulletType.GetComponent<Bullet>().DamageIncreaseAmount + ".";

        bulletPool.OnBulletTypeChanged += BulletPool_OnBulletTypeChanged;

        bulletDamageUpgradeButton.onClick.AddListener(UpgradeConfirmation);
    }

    private void BulletPool_OnBulletTypeChanged(object sender, System.EventArgs e)
    {
        purchasingExplanationTextWithDamageAmount = purchasingExplanationText + " " + bulletPool.PlayerWeapon.BulletType.GetComponent<Bullet>().DamageIncreaseAmount + ".";
    }

    private void UpgradeBulletDamage()
    {
        bulletPool.UpgradePooledBulletDamage();

        if(bulletPool.BulletDamageLevel >= bulletPool.BulletDamageMaxLevel)
        {
            maxInfoPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void UpgradeConfirmation()
    {
        ConfirmationUI.Instance.PopConfirmationWindow(UpgradeBulletDamage, purchasingExplanationTextWithDamageAmount, bulletPool.BulletDamageUpgradeCost);
    }
}
