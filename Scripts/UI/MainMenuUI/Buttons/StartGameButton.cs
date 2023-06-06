using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private GameObject difficultyOptionsButtons;
    [SerializeField] private GameObject soundSlider;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject title;

    private Button startGameButton;

    void Start()
    {
        startGameButton = GetComponent<Button>();

        startGameButton.onClick.AddListener(ActivateDifficultyOptions);
    }

    private void ActivateDifficultyOptions()
    {
        difficultyOptionsButtons.SetActive(true);

        title.SetActive(false);
        quitButton.SetActive(false);
        soundSlider.SetActive(false);
        gameObject.SetActive(false);
    }
}
