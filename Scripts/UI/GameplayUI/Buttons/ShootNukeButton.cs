using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootNukeButton : MonoBehaviour
{
    [SerializeField] private NukeWeaponShootingPoint nukeWeaponShootingPoint;

    private Button shootNukeButton;

    void Start()
    {
        shootNukeButton = GetComponent<Button>();

        nukeWeaponShootingPoint.OnWeaponCanShoot += NukeWeaponShootingPoint_OnWeaponCanShoot;

        shootNukeButton.onClick.AddListener(nukeWeaponShootingPoint.Shoot);
        shootNukeButton.onClick.AddListener(DisableOnClick);
    }

    private void NukeWeaponShootingPoint_OnWeaponCanShoot(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
    }

    private void DisableOnClick()
    {
        gameObject.SetActive(false);
    }
}
