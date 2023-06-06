using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapActivateButton : MonoBehaviour
{
    [SerializeField] private MineField mineField;

    private Button detonateAllMinesButton;

    private void Awake()
    {
        detonateAllMinesButton = GetComponent<Button>();

        detonateAllMinesButton.onClick.AddListener(mineField.StartDetonating);
    }

    private void Start()
    {
        mineField.OnActiveSelfChanged += MineField_OnActiveSelfChanged;

        gameObject.SetActive(false);
    }

    private void MineField_OnActiveSelfChanged(object sender, System.EventArgs e)
    {
        if (mineField.gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
