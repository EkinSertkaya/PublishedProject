using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateMinesButton : MonoBehaviour
{
    [SerializeField] private MineField mineField;

    [TextArea(10, 10)]
    [SerializeField] private string purchasingExplanationText;

    private int cost = 2000;

    private Button activateMinesButton;

    private void Start()
    {
        activateMinesButton = GetComponent<Button>();

        activateMinesButton.onClick.AddListener(UpgradeConfirmation);

        mineField.OnActiveSelfChanged += MineField_OnActiveSelfChanged;
    }

    private void MineField_OnActiveSelfChanged(object sender, System.EventArgs e)
    {
        if (mineField.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else if (!mineField.gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    private void UpgradeConfirmation()
    {
        ConfirmationUI.Instance.PopConfirmationWindow(mineField.ActivateField, purchasingExplanationText, cost);
    }
}
