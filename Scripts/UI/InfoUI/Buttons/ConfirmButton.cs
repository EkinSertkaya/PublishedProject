using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmButton : MonoBehaviour
{
    private Button confirmButton;

    private bool gameCompleted = false;

    private void Start()
    {
        confirmButton = GetComponent<Button>();

        confirmButton.onClick.AddListener(ConfirmAndClosePopUpWindow);
    }

    private void ConfirmAndClosePopUpWindow()
    {
        PopUpWindow.Instance.gameObject.SetActive(false);

        if (gameCompleted)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GameCompleted()
    {
        gameCompleted = true;
    }
}
