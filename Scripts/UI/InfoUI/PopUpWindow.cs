using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpWindow : MonoBehaviour
{
    public static PopUpWindow Instance { get; private set; }

    private TextMeshProUGUI popUpWindowText;

    [SerializeField] private ConfirmButton confirmButton;
    public ConfirmButton ConfirmButton { get { return confirmButton; } }

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        popUpWindowText = GetComponentInChildren<TextMeshProUGUI>();

        gameObject.SetActive(false);
    }

    public void PopWithText(string showedText)
    {
        gameObject.SetActive(true);
        popUpWindowText.text = showedText;
    }
}
