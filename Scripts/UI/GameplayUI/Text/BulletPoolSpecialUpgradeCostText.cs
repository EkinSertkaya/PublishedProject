using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletPoolSpecialUpgradeCostText : MonoBehaviour
{
    private BulletPool bulletPool;

    private TextMeshProUGUI specialUpgradeCostText;

    private void Start()
    {
        bulletPool = GetComponentInParent<UpgradeBulletSpecialButton>().BulletPool;

        bulletPool.OnBulletSpecialUpgraded += BulletPool_OnBulletSpecialUpgraded;

        specialUpgradeCostText = GetComponent<TextMeshProUGUI>();

        UpdateSpecialUpgradeCost();
    }

    private void BulletPool_OnBulletSpecialUpgraded(object sender, System.EventArgs e)
    {
        UpdateSpecialUpgradeCost();
    }

    private void UpdateSpecialUpgradeCost()
    {
        specialUpgradeCostText.text = bulletPool.BulletSpecialUpgradeCost.ToString();
    }
}
