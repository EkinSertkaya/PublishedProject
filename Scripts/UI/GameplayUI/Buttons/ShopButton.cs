using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;

    private Button shopButton;

    private void Start()
    {
        shopButton = GetComponent<Button>();

        shopButton.onClick.AddListener(ShowHideShopUI);
    }

    public void ShowHideShopUI()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }
}
