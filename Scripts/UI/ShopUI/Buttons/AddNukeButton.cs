using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNukeButton : MonoBehaviour
{
    private Button addNukeButton;

    [SerializeField] private GameObject nukeWeapon;
    [SerializeField] private GameObject nukeShootButtonGameObject;

    [TextArea(10, 10)]
    [SerializeField] private string purchasingExplanationText;

    private int cost = 25000;

    private NukeWeaponShootingPoint nukeWeaponShootingPoint;

    private void Start()
    {
        addNukeButton = GetComponent<Button>();

        nukeWeaponShootingPoint = nukeWeapon.GetComponentInChildren<NukeWeaponShootingPoint>();

        addNukeButton.onClick.AddListener(ConfirmationAddNukeWeapon);
    }

    private void AddNukeWeapon()
    {
        if(PlayerEconomy.Instance.PlayerMoney >= nukeWeaponShootingPoint.NukeWeaponCost)
        {
            PlayerEconomy.Instance.SpendMoney(nukeWeaponShootingPoint.NukeWeaponCost);

            nukeWeapon.SetActive(true);
            nukeShootButtonGameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void ConfirmationAddNukeWeapon()
    {
        ConfirmationUI.Instance.PopConfirmationWindow(AddNukeWeapon, purchasingExplanationText, cost);
    }
}
