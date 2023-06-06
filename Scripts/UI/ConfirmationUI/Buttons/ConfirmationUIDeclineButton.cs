using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationUIDeclineButton : MonoBehaviour
{
    private Button confirmationUIDeclineButton;

    private void Start()
    {
        confirmationUIDeclineButton = GetComponent<Button>();

        confirmationUIDeclineButton.onClick.AddListener(DeclineConfirmedMethod);
    }

    private void DeclineConfirmedMethod()
    {
        ConfirmationUI.Instance.DeclineTakenAction();

        ConfirmationUI.Instance.gameObject.SetActive(false);
    }
}
