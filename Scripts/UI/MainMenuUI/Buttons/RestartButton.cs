using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private Button restartButton;

    void Start()
    {
        restartButton = GetComponent<Button>();

        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
