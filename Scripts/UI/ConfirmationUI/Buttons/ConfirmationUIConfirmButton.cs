using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationUIConfirmButton : MonoBehaviour
{
    private Button confirmationUIConfirmButton;

    private Action confirmedMethod;

    void Start()
    {
        confirmationUIConfirmButton = GetComponent<Button>();

        confirmationUIConfirmButton.onClick.AddListener(RunConfirmedMethod);
    }

    public void SetConfirmedMethod(Action confirmingMethod)
    {
        confirmedMethod += confirmingMethod;
    }

    private void RunConfirmedMethod()
    {
        confirmedMethod();

        ResetConfiredMethod();

        ConfirmationUI.Instance.gameObject.SetActive(false);
    }

    public void ResetConfiredMethod()
    {
        confirmedMethod = null;
    }
}
