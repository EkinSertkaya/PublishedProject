using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletPoolDamageUpgradeCostText : MonoBehaviour
{
    private BulletPool bulletPool;

    private TextMeshProUGUI damageUpgradeCostText;

    private void Start()
    {
        bulletPool = GetComponentInParent<UpgradeBulletDamageButton>().BulletPool;

        bulletPool.OnBulletDamageUpgraded += BulletPool_OnBulletDamageUpgraded;

        damageUpgradeCostText = GetComponent<TextMeshProUGUI>();

        UpdateDamageUpgradeCost();
    }

    private void BulletPool_OnBulletDamageUpgraded(object sender, System.EventArgs e)
    {
        UpdateDamageUpgradeCost();
    }

    private void UpdateDamageUpgradeCost()
    {
        damageUpgradeCostText.text = bulletPool.BulletDamageUpgradeCost.ToString();
    }
   
}
