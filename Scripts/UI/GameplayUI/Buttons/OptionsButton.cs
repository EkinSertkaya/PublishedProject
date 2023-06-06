using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;

    private Button optionsButton;

    private void Start()
    {
        optionsButton = GetComponent<Button>();

        optionsButton.onClick.AddListener(PauseGame);
    }

    private void PauseGame()
    {
        mainMenuUI.SetActive(!mainMenuUI.activeSelf);

        if (mainMenuUI.activeSelf)
        {
            Time.timeScale = 0;
        }
        else if (!mainMenuUI.activeSelf)
        {
            Time.timeScale = 1;
        }
    }
}
