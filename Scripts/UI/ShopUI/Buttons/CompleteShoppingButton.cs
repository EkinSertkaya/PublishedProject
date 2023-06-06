using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteShoppingButton : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private PlayerWeapon playerWeapon;
    [SerializeField] private GameObject gameplayUI;

    private Button completeShoppingButton;

    private void Start()
    {
        completeShoppingButton = GetComponent<Button>();

        completeShoppingButton.onClick.AddListener(CompleteShopping);
    }

    private void CompleteShopping()
    {
        RulesManager.Instance.StartNextLevel();
        MonsterSpawner.Instance.ResetMonsterCounter();
        MonsterSpawner.Instance.SetSpawningTrue();
        playerWeapon.ResetWeaponRotation();
        gameplayUI.SetActive(true);
        shopUI.gameObject.SetActive(false);
    }
}
