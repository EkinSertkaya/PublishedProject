using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyOptionButton : MonoBehaviour
{
    [SerializeField] private DifficultyType difficultyType;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject difficultyOptionsButtonsMenu;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject soundSlider;
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject restartButton;

    private Button difficultyOptionButton;

    private void Start()
    {
        difficultyOptionButton = GetComponent<Button>();

        difficultyOptionButton.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        RulesManager.Instance.SetDifficulty(difficultyType);
        DisableMainMenu();
    }

    private void DisableMainMenu()
    {
        difficultyOptionsButtonsMenu.gameObject.SetActive(false);

        restartButton.SetActive(true);
        title.SetActive(true);
        quitButton.SetActive(true);
        optionsButton.SetActive(true);
        soundSlider.SetActive(true);
        mainMenuUI.gameObject.SetActive(false);
    }
}
