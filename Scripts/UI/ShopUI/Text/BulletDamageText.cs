using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletDamageText : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;

    private TextMeshProUGUI bulletDamageStatText;

    private BulletType bulletType;

    private void Start()
    {
        bulletDamageStatText = GetComponent<TextMeshProUGUI>();

        bulletPool.OnBulletTypeChanged += BulletPool_OnBulletTypeChanged;
        bulletPool.OnBulletDamageUpgraded += BulletPool_OnBulletDamageUpgraded;

        SetDefaultDamage();
    }

    private void BulletPool_OnBulletDamageUpgraded(object sender, System.EventArgs e)
    {
        SetDefaultDamage();
    }

    private void BulletPool_OnBulletTypeChanged(object sender, System.EventArgs e)
    {
        SetDefaultDamage();
    }

    private void SetDefaultDamage()
    {
        bulletType = bulletPool.PooledBulletList[0].GetComponent<Bullet>().BulletType;

        switch (bulletType)
        {
            case global::BulletType.SmallBullet:
                bulletDamageStatText.text = "Damage        : " + bulletPool.PooledBulletList[0].GetComponent<SmallBullet>().DamageAmount.ToString();
                break;
            case global::BulletType.PoisonBullet:
                bulletDamageStatText.text = "Damage        : " + bulletPool.PooledBulletList[0].GetComponent<PoisonBullet>().DamageAmount.ToString();
                break;
            case global::BulletType.Arrow:
                bulletDamageStatText.text = "Damage        : " + bulletPool.PooledBulletList[0].GetComponent<Arrow>().DamageAmount.ToString();
                break;
            case global::BulletType.PoisonRocket:
                bulletDamageStatText.text = "Damage        : " + bulletPool.PooledBulletList[0].GetComponent<PoisonRocket>().DamageAmount.ToString();
                break;
            case global::BulletType.Rocket:
                bulletDamageStatText.text = "Damage        : " + bulletPool.PooledBulletList[0].GetComponent<Rocket>().DamageAmount.ToString();
                break;
            case global::BulletType.TimedExplosive:
                bulletDamageStatText.text = "Damage        : " + bulletPool.PooledBulletList[0].GetComponent<TimedBomb>().DamageAmount.ToString();
                break;
        }
    }
}
