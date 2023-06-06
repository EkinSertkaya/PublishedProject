using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateAirStrikeButton : MonoBehaviour
{
    [SerializeField] private GameObject startBombingButtonGameObject;

    [TextArea(10, 10)]
    [SerializeField] private string purchasingExplanationText;

    private AirStrike airStrike;

    private Button activateAirStrikeButton;

    private StartBombingButton startBombingButton;

    private int cost = 20000;

    private void Start()
    {
        activateAirStrikeButton = GetComponent<Button>();

        startBombingButton = startBombingButtonGameObject.GetComponent<StartBombingButton>();

        airStrike = startBombingButtonGameObject.GetComponent<StartBombingButton>().AirStrike;

        activateAirStrikeButton.onClick.AddListener(UpgradeConfirmation);

        startBombingButton.OnStartBombingButtonActiveSelfChanged += StartBombingButton_OnStartBombingButtonActiveSelfChanged;
    }

    private void StartBombingButton_OnStartBombingButtonActiveSelfChanged(object sender, System.EventArgs e)
    {
        if (startBombingButtonGameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else if (!startBombingButtonGameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    private void ActivateAirStrike()
    {
        if(PlayerEconomy.Instance.PlayerMoney >= airStrike.AirStrikeCost)
        {
            PlayerEconomy.Instance.SpendMoney(airStrike.AirStrikeCost);

            startBombingButton.ActivateStartBombingButton();
        }
    }

    private void UpgradeConfirmation()
    {
        ConfirmationUI.Instance.PopConfirmationWindow(ActivateAirStrike, purchasingExplanationText, cost);
    }
}
