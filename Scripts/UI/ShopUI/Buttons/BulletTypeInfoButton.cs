using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletTypeInfoButton : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;

    private Button bulletTypeInfoButton;

    private string bulletTypeInfoText;

    private void Start()
    {
        bulletTypeInfoButton = GetComponent<Button>();

        bulletTypeInfoButton.onClick.AddListener(PopBulletSpecialInfo);

        SetBulletTypeInfoText();
        bulletPool.OnBulletTypeChanged += BulletPool_OnBulletTypeChanged;
        bulletPool.OnBulletSpecialUpgraded += BulletPool_OnBulletSpecialUpgraded;
    }

    private void BulletPool_OnBulletSpecialUpgraded(object sender, System.EventArgs e)
    {
        SetBulletTypeInfoText();
    }

    private void BulletPool_OnBulletTypeChanged(object sender, System.EventArgs e)
    {
        SetBulletTypeInfoText();
    }

    private void SetBulletTypeInfoText()
    {
        switch(bulletPool.PlayerWeapon.BulletType.GetComponent<Bullet>().BulletType)
        {
            case global::BulletType.SmallBullet:
                bulletTypeInfoText = "Critical chance is " + bulletPool.PooledBulletList[0].GetComponent<SmallBullet>().CriticalChance.ToString() + "%";
                break;
            case global::BulletType.PoisonBullet:
                bulletTypeInfoText = "Poison damage per second is " + bulletPool.PooledBulletList[0].GetComponent<PoisonBullet>().PoisonDamage.ToString();
                break;
            case global::BulletType.Arrow:
                bulletTypeInfoText = "Stun chance is " + bulletPool.PooledBulletList[0].GetComponent<Arrow>().StunChancePercentage.ToString() + "%";
                break;
            case global::BulletType.PoisonRocket:
                bulletTypeInfoText = "Posion damage per second is " + bulletPool.PooledBulletList[0].GetComponent<PoisonRocket>().PoisonDamage.ToString();
                break;
            case global::BulletType.Rocket:
                bulletTypeInfoText = "Explosion radius is " + string.Format("{0:0.#}", bulletPool.PooledBulletList[0].GetComponent<Rocket>().DamageRadius)  + " units.";
                break;
            case global::BulletType.TimedExplosive:
                bulletTypeInfoText = "Detonation time is " + string.Format("{0:0.#}", bulletPool.PooledBulletList[0].GetComponent<TimedBomb>().DetonateTime) + " seconds.";
                break;
        }
    }

    private void PopBulletSpecialInfo()
    {
        PopUpWindow.Instance.PopWithText(bulletTypeInfoText);
    }
}
