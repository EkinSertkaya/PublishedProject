using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button quitButton;

    private void Start()
    {
        quitButton = GetComponent<Button>();

        quitButton.onClick.AddListener(Application.Quit);
    }
}
