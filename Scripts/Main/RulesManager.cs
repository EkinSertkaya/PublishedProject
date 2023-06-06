using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesManager : MonoBehaviour
{
    public static RulesManager Instance { get; private set; }

    private DifficultyType activeDifficulty;
    public DifficultyType ActiveDifficulty { get { return activeDifficulty; } }

    public event EventHandler OnGameOver;
    public event EventHandler OnLevelComplete;
    public event EventHandler OnDifficultySet;

    private int killedMonsterAmount = 0;

    private int passedMonsterAmount = 0;
    public int PassedMonsterAmount { get { return passedMonsterAmount; } }

    private int passedMonsterLimitForEnd = 100;
    public int PassedMonsterLimitForEnd { get { return passedMonsterLimitForEnd; } }

    private int level = 1;
    public int Level { get { return level; } }

    private int monsterAmountThisLevel = 0;
    public int MonsterAmountThisLevel { get { return monsterAmountThisLevel; } }

    private int smallMonsterAmount = 1;
    public int SmallMonsterAmount { get { return smallMonsterAmount; } }

    private int mediumMonsterAmount = 0;
    public int MediumMonsterAmount { get { return mediumMonsterAmount; } }

    private int bigMonsterAmount = 0;
    public int BigMonsterAmount { get { return bigMonsterAmount; } }

    private int bossMonsterAmount = 0;
    public int BossMonsterAmount { get { return bossMonsterAmount; } }

    private int maxMonsterLimitOnHard = 100;
    private int maxMonsterLimitOnNormal = 200;
    private int maxMonsterLimitOnEasy = 400;
    private int maxMonsterLimitOnJustLetMePlay = 999999;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        monsterAmountThisLevel = smallMonsterAmount + mediumMonsterAmount + bigMonsterAmount + bossMonsterAmount;
    }

    private void Start()
    {
        MonsterTarget.OnMonsterPassed += MonsterTarget_OnMonsterPassed;
        OnGameOver += RulesManager_OnGameOver;
    }

    private void RulesManager_OnGameOver(object sender, EventArgs e)
    {
        SceneManager.LoadScene(0);
    }

    private void MonsterTarget_OnMonsterPassed(object sender, System.EventArgs e)
    {
        passedMonsterAmount++;

        if(passedMonsterAmount >= passedMonsterLimitForEnd)
        {
            passedMonsterAmount = 0;
            OnGameOver?.Invoke(null, EventArgs.Empty);
        }
    }

    public void IncrementKilledMonsterAmount()
    {
        killedMonsterAmount++;

        if (killedMonsterAmount >= monsterAmountThisLevel)
        {
            level++;

            if(level >= 21)
            {
                PopUpWindow.Instance.ConfirmButton.GameCompleted();

                PopUpWindow.Instance.PopWithText("CONGRATULATIONS, YOU COMPLETED THE GAME!");
                return;
            }

            OnLevelComplete(null, EventArgs.Empty);
        }
    }

    public void ResetKilledMonsterAmount()
    {
        killedMonsterAmount = 0;
    }

    public void StartNextLevel()
    {
        SetMonsterAmountThisLevel();
        ResetKilledMonsterAmount();
    }

    private void SetMonsterAmountThisLevel()
    {
        switch (level)
        {
            case 2:
                SetMonsterAmount(3);
                break;
            case 3:
                SetMonsterAmount(10);
                break;
            case 4:
                SetMonsterAmount(10);
                break;
            case 5:
                SetMonsterAmount(20);
                break;
            case 6:
                SetMonsterAmount(25, 5);
                break;
            case 7:
                SetMonsterAmount(35, 7);
                break;
            case 8:
                SetMonsterAmount(40, 10);
                break;
            case 9:
                SetMonsterAmount(40, 15);
                break;
            case 10:
                SetMonsterAmount(60, 20, 4);
                break;
            case 11:
                SetMonsterAmount(65, 20, 8);
                break;
            case 12:
                SetMonsterAmount(65, 20, 10);
                break;
            case 13:
                SetMonsterAmount(105, 30, 12);
                break;
            case 14:
                SetMonsterAmount(105, 30, 15);
                break;
            case 15:
                SetMonsterAmount(105, 30, 20, 3);
                break;
            case 16:
                SetMonsterAmount(120, 40, 25, 4);
                break;
            case 17:
                SetMonsterAmount(130, 45, 20, 4);
                break;
            case 18:
                SetMonsterAmount(140, 45, 20, 6);
                break;
            case 19:
                SetMonsterAmount(150, 45, 20, 9);
                break;
            case 20:
                SetMonsterAmount(160, 50, 20, 12);
                break;

        }
    }

    private int SetMonsterAmount(int smallMonsterNumber = 0, int mediumMonsterNumber = 0, int bigMonsterNumber = 0, int bossMonsterNumber = 0)
    {
        smallMonsterAmount = smallMonsterNumber;
        mediumMonsterAmount = mediumMonsterNumber;
        bigMonsterAmount = bigMonsterNumber;
        bossMonsterAmount = bossMonsterNumber;

        monsterAmountThisLevel = smallMonsterAmount + mediumMonsterAmount + bigMonsterAmount + bossMonsterAmount;

        return monsterAmountThisLevel;
    }

    public void SetPassedMonsterLimitForEnd(int limit)
    {
        passedMonsterLimitForEnd = limit;
    }

    public void SetDifficulty(DifficultyType difficultyType)
    {
        activeDifficulty = difficultyType;

        switch (difficultyType)
        {
            case DifficultyType.Hard:
                SetPassedMonsterLimitForEnd(maxMonsterLimitOnHard);
                OnDifficultySet?.Invoke(this, EventArgs.Empty);
                break;
            case DifficultyType.Normal:
                SetPassedMonsterLimitForEnd(maxMonsterLimitOnNormal);
                OnDifficultySet?.Invoke(this, EventArgs.Empty);
                break;
            case DifficultyType.Easy:
                SetPassedMonsterLimitForEnd(maxMonsterLimitOnEasy);
                OnDifficultySet?.Invoke(this, EventArgs.Empty);
                break;
            case DifficultyType.JustLetMePlay:
                SetPassedMonsterLimitForEnd(maxMonsterLimitOnJustLetMePlay);
                OnDifficultySet?.Invoke(this, EventArgs.Empty);
                break;
        }

        MonsterSpawner.Instance.StartSpawning();
    }
}
