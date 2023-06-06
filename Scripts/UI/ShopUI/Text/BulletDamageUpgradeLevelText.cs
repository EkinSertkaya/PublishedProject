using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletDamageUpgradeLevelText : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool;

    private TextMeshProUGUI bulletDamageUpgradeLevelText;

    private void Start()
    {
        bulletDamageUpgradeLevelText = GetComponent<TextMeshProUGUI>();

        bulletPool.OnBulletDamageUpgraded += BulletPool_OnBulletDamageUpgraded;

        bulletDamageUpgradeLevelText.text = ": Level " + bulletPool.BulletDamageLevel;
    }

    private void BulletPool_OnBulletDamageUpgraded(object sender, System.EventArgs e)
    {
        bulletDamageUpgradeLevelText.text = ": Level " + bulletPool.BulletDamageLevel;
    }
}
