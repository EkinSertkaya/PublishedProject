using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private BulletType bulletType;
    public BulletType BulletType { get { return bulletType; } }

    [SerializeField] private int cost;
    public int Cost { get { return cost; } }

    [SerializeField] protected int damageIncreaseAmount;
    public int DamageIncreaseAmount { get { return damageIncreaseAmount; } }

    private PlayerWeapon playerWeapon;
    public PlayerWeapon PlayerWeapon { get { return playerWeapon; } set { playerWeapon = value; } }

    protected Rigidbody2D bulletRb;

    private int ignoreFirstEnable = 0;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    abstract public void UpgradeBulletDamage();

    abstract public void UpgradeBulletSpecial();
    
    private void OnEnable()
    {
        if (ignoreFirstEnable == 0)
        {
            ignoreFirstEnable++;
            return;
        }

        if(bulletType == BulletType.Nuke)
        {
            bulletRb.AddForce(transform.right * 100, ForceMode2D.Impulse);
        }
        else
        {
            bulletRb.AddForce(transform.right * playerWeapon.BulletVelocity, ForceMode2D.Impulse);
        }
    }
}
