using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeWeaponShootingPoint : MonoBehaviour
{
    public event EventHandler OnWeaponCanShoot;

    [SerializeField] private NukePool nukePool;

    private bool canShoot = true;

    private float nukeWeaponRateOfFire = 60f;
    private float nukeWeaponTimer = 0f;

    private int nukeWeaponCost = 25000;
    public int NukeWeaponCost { get { return nukeWeaponCost; } }

    private void Start()
    {
        RulesManager.Instance.OnLevelComplete += Instance_OnLevelComplete;
    }

    private void Instance_OnLevelComplete(object sender, System.EventArgs e)
    {
        ResetNukeWeapon();
    }

    private void Update()
    {
        if (!canShoot)
        {
            nukeWeaponTimer += Time.deltaTime;

            if (nukeWeaponTimer >= nukeWeaponRateOfFire)
            {
                canShoot = true;

                nukeWeaponTimer -= nukeWeaponTimer;

                OnWeaponCanShoot?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            GameObject nukeBullet;

            nukeBullet = nukePool.GetNukeFromPool();

            nukeBullet.transform.position = transform.position;
            nukeBullet.transform.rotation = transform.rotation;

            nukeBullet.SetActive(true);

            canShoot = false;
        }
    }

    private void ResetNukeWeapon()
    {
        canShoot = true;
        nukeWeaponTimer -= nukeWeaponTimer;

        OnWeaponCanShoot?.Invoke(this, EventArgs.Empty);
    }
}
