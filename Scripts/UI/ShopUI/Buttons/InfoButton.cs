using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    [TextArea(10, 10)]
    [SerializeField] private string infoText;

    private Button infoButton;

    private void Start()
    {
        infoButton = GetComponent<Button>();

        infoButton.onClick.AddListener(ActivatePopUpWindow);
    }

    private void ActivatePopUpWindow()
    {
        PopUpWindow.Instance.PopWithText(infoText);
    }
}
