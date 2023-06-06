using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBulletSpecialButton : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    public BulletPool BulletPool { get { return bulletPool; } }

    [SerializeField] private GameObject maxInfoPanel;

    private Button bulletSpecialUpgradeButton;

    [TextArea(10, 10)]
    [SerializeField] private string purchasingExplanationText;

    private void Start()
    {
        bulletSpecialUpgradeButton = GetComponent<Button>();

        bulletSpecialUpgradeButton.onClick.AddListener(UpgradeConfirmation);

        bulletPool.OnBulletTypeChanged += BulletPool_OnBulletTypeChanged;

        UpdatePurchasingExplanationText();
    }

    private void BulletPool_OnBulletTypeChanged(object sender, System.EventArgs e)
    {
        UpdatePurchasingExplanationText();
    }

    private void UpgradeBulletSpecial()
    {
        bulletPool.UpgradePooledBulletSpecial();

        if (bulletPool.BulletSpecialLevel >= bulletPool.BulletSpecialMaxLevel)
        {
            maxInfoPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void UpgradeConfirmation()
    {
            ConfirmationUI.Instance.PopConfirmationWindow(UpgradeBulletSpecial, purchasingExplanationText, bulletPool.BulletSpecialUpgradeCost);
    }

    private void UpdatePurchasingExplanationText()
    {
        switch (bulletPool.PlayerWeapon.BulletType.GetComponent<Bullet>().BulletType)
        {
            case BulletType.SmallBullet:
                purchasingExplanationText = "Increase the crital chance of the bullet by 2%.";
                break;
            case global::BulletType.PoisonBullet:
                purchasingExplanationText = "Increase poison damage by 25.";
                break;
            case global::BulletType.Arrow:
                purchasingExplanationText = "Increase stun chance by 3%.";
                break;
            case global::BulletType.PoisonRocket:
                purchasingExplanationText = "Increase poison damage by 20.";
                break;
            case global::BulletType.Rocket:
                purchasingExplanationText = "Increase the explosion radius by 0.1.";
                break;
            case global::BulletType.TimedExplosive:
                purchasingExplanationText = "Decrease detonation time by 0.2 seconds.";
                break;
        }
    }
}
