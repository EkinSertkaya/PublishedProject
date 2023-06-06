using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBulletButton : MonoBehaviour
{
    [SerializeField] private PlayerWeapon playerWeapon;

    [TextArea(10, 10)]
    [SerializeField] private string purchasingExplanationText;

    [SerializeField] private GameObject bulletType;
    public GameObject BulletType { get { return bulletType; } }

    [SerializeField] private int cost;

    private Button upgradeBulletButton;

    private Bullet thisBulletType;

    private void Start()
    {
        upgradeBulletButton = GetComponent<Button>();

        upgradeBulletButton.onClick.AddListener(UpgradeConfirmation);

        playerWeapon.OnBulletTypeChanged += PlayerWeapon_OnBulletTypeChanged;

        if(bulletType == playerWeapon.BulletType)
        {
            gameObject.SetActive(false);
        }
    }

    private void PlayerWeapon_OnBulletTypeChanged(object sender, EventArgs e)
    {
        if (!gameObject.activeSelf)
        {
            if(playerWeapon.BulletType.GetComponent<Bullet>().BulletType != bulletType.GetComponent<Bullet>().BulletType)
            {
                gameObject.SetActive(true);
            }
        }
    }

    private void SetBulletType()
    {
        if (PlayerEconomy.Instance.PlayerMoney >= cost)
        {
            gameObject.SetActive(false);
        }

        playerWeapon.SetBulletType(bulletType);
    }

    private void UpgradeConfirmation()
    {
        thisBulletType = bulletType.GetComponent<Bullet>();

        ConfirmationUI.Instance.PopConfirmationWindow(SetBulletType, purchasingExplanationText, thisBulletType.Cost);
    }
}
