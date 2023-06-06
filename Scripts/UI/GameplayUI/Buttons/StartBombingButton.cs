using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBombingButton : MonoBehaviour
{
    public event EventHandler OnStartBombingButtonActiveSelfChanged;

    [SerializeField] private AirStrike airStrike;
    public AirStrike AirStrike { get { return airStrike; } }

    private Button activateAirStrikeButton;

    private void Start()
    {
        activateAirStrikeButton = GetComponent<Button>();

        activateAirStrikeButton.onClick.AddListener(ActivateBombing);
    }

    private void ActivateBombing()
    {
        airStrike.ActivateBombing();

        gameObject.SetActive(false);

        OnStartBombingButtonActiveSelfChanged?.Invoke(this, EventArgs.Empty);
    }

    public void ActivateStartBombingButton()
    {
        gameObject.SetActive(true);

        OnStartBombingButtonActiveSelfChanged?.Invoke(this, EventArgs.Empty);
    }
}
