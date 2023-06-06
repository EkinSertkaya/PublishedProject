using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmationUI : MonoBehaviour
{
    public static ConfirmationUI Instance { get; private set; }

    [SerializeField] private ConfirmationUIConfirmButton confirmationUIConfirmButton;

    [SerializeField] private TextMeshProUGUI confirmationText;

    [SerializeField] private TextMeshProUGUI costText;

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

        gameObject.SetActive(false);
    }

    public void PopConfirmationWindow(Action takenAction, string confirmationText, int cost)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);

            confirmationUIConfirmButton.SetConfirmedMethod(takenAction);
        }

        this.confirmationText.text = confirmationText;

        this.costText.text = cost.ToString();
    }

    public void DeclineTakenAction()
    {
        confirmationUIConfirmButton.ResetConfiredMethod();
    }
}
