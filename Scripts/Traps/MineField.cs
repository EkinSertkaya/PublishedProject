using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineField : MonoBehaviour
{
    public event EventHandler OnActiveSelfChanged;

    private Mine[] allMines;

    private bool detonating = false;

    private float detonationInterval = 0.05f;
    private float detonationTimer = 0f;

    private int mineIndex = 0;

    private int mineCost = 2000;

    private void Awake()
    {
        allMines = GetComponentsInChildren<Mine>();
    }

    private void Update()
    {
        if (detonating)
        {
            detonationTimer += Time.deltaTime;

            if(detonationTimer >= detonationInterval)
            {
                allMines[mineIndex].Detonate();

                detonationTimer -= detonationTimer;

                mineIndex++;

                if(mineIndex >= allMines.Length)
                {
                    mineIndex = 0;

                    foreach (Mine mine in allMines)
                    {
                        mine.ActivateMine();
                    }

                    detonating = false;

                    gameObject.SetActive(false);

                    OnActiveSelfChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    public void StartDetonating()
    {
        detonating = true;
    }

    public void ActivateField()
    {
        if(PlayerEconomy.Instance.PlayerMoney >= mineCost)
        {
            PlayerEconomy.Instance.SpendMoney(mineCost);

            gameObject.SetActive(true);

            OnActiveSelfChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
