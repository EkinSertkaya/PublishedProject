using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrike : MonoBehaviour
{
    private Transform[] airBombsArray = new Transform[6];

    private bool isBombing = false;

    private bool isActive = false;
    public bool IsActive { get { return isActive; } }

    private float delayBetweenBombs = 0.2f;
    private float bombDelayTimer = 0f;

    private int activatedBombIndex = 0;

    private int airStrikeCost = 20000;
    public int AirStrikeCost { get { return airStrikeCost; } }

    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            airBombsArray[i] = transform.GetChild(i);
            airBombsArray[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        StartBombing();
    }

    private void StartBombing()
    {
        if (isBombing)
        {
            bombDelayTimer += Time.deltaTime;

            if(bombDelayTimer >= delayBetweenBombs)
            {
                airBombsArray[activatedBombIndex].gameObject.SetActive(true);

                activatedBombIndex++;

                if(activatedBombIndex >= 6)
                {
                    activatedBombIndex -= activatedBombIndex;

                    isBombing = false;
                }

                bombDelayTimer -= bombDelayTimer;
            }
        }
    }

    public void ActivateBombing()
    {
        isBombing = true;
    }
}
