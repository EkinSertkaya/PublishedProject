using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletUpgradeCostText : MonoBehaviour
{
    private Bullet bullet;

    private TextMeshProUGUI bulletUpgradeCostText;

    private void Awake()
    {
        bullet = GetComponentInParent<UpgradeBulletButton>().BulletType.GetComponent<Bullet>();

        bulletUpgradeCostText = GetComponent<TextMeshProUGUI>();

        bulletUpgradeCostText.text = bullet.Cost.ToString();
    }
}
