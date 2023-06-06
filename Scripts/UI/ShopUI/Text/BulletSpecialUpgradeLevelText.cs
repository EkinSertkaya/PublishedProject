using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletSpecialUpgradeLevelText : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool;

    private TextMeshProUGUI bulletSpecialUpgradeLevelText;

    private void Start()
    {
        bulletSpecialUpgradeLevelText = GetComponent<TextMeshProUGUI>();

        bulletPool.OnBulletSpecialUpgraded += BulletPool_OnBulletSpecialUpgraded;

        bulletSpecialUpgradeLevelText.text = ": Level " + bulletPool.BulletSpecialLevel;
    }

    private void BulletPool_OnBulletSpecialUpgraded(object sender, System.EventArgs e)
    {
        bulletSpecialUpgradeLevelText.text = ": Level " + bulletPool.BulletSpecialLevel;
    }
}
