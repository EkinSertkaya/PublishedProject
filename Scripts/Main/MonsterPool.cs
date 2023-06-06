using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public static MonsterPool Instance { get; private set; }

    [SerializeField] private GameObject small1;
    [SerializeField] private GameObject small2;
    [SerializeField] private GameObject small3;

    [SerializeField] private GameObject medium1;
    [SerializeField] private GameObject medium2;
    [SerializeField] private GameObject medium3;

    [SerializeField] private GameObject big1;
    [SerializeField] private GameObject big2;
    [SerializeField] private GameObject big3;

    [SerializeField] private GameObject boss1;
    [SerializeField] private GameObject boss2;
    [SerializeField] private GameObject boss3;

    private List<GameObject>[] smallMonsterPool = new List<GameObject>[3];
    private List<GameObject>[] mediumMonsterPool = new List<GameObject>[3];
    private List<GameObject>[] bigMonsterPool = new List<GameObject>[3];
    private List<GameObject>[] bossMonsterPool = new List<GameObject>[3];

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
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            smallMonsterPool[i] = new List<GameObject>();
            mediumMonsterPool[i] = new List<GameObject>();
            bigMonsterPool[i] = new List<GameObject>();
            bossMonsterPool[i] = new List<GameObject>();
        }

        SetFirstArrayLists();
    }

    private void SetFirstArrayLists()
    {
        for (int i = 0; i < 30; i++)
        {
            PoolMonsters(small1, smallMonsterPool, 0);
            PoolMonsters(small2, smallMonsterPool, 1);
            PoolMonsters(small3, smallMonsterPool, 2);

            PoolMonsters(medium1, mediumMonsterPool, 0);
            PoolMonsters(medium2, mediumMonsterPool, 1);
            PoolMonsters(medium3, mediumMonsterPool, 2);

            PoolMonsters(big1, bigMonsterPool, 0);
            PoolMonsters(big2, bigMonsterPool, 1);
            PoolMonsters(big3, bigMonsterPool, 2);

            PoolMonsters(boss1, bossMonsterPool, 0);
            PoolMonsters(boss2, bossMonsterPool, 1);
            PoolMonsters(boss3, bossMonsterPool, 2);
        }
    }

    private void PoolMonsters(GameObject pooledMonster, List<GameObject>[] poolArray, int poolIndex)
    {
        GameObject monster = Instantiate(pooledMonster, transform.position, Quaternion.identity, transform);
        poolArray[poolIndex].Add(monster);
        monster.SetActive(false);
    }

    public GameObject GetRandomMonster(CreatureType creatureType)
    {
        int randomMonsterList = Random.Range(0, 3);

        switch (creatureType)
        {
            case CreatureType.SmallMonster:
                return GetRandomMonsterFromList(smallMonsterPool, randomMonsterList);

            case CreatureType.MediumMonster:
                return GetRandomMonsterFromList(mediumMonsterPool, randomMonsterList);

            case CreatureType.BigMonster:
                return GetRandomMonsterFromList(bigMonsterPool, randomMonsterList);

            case CreatureType.BossMonster:
                return GetRandomMonsterFromList(bossMonsterPool, randomMonsterList);
        }

        return null;
    }

    private GameObject GetRandomMonsterFromList(List<GameObject>[] monsterList, int randomArrayNumer)
    {
        foreach (GameObject monster in monsterList[randomArrayNumer])
        {
            if (!monster.activeSelf)
            {
                return monster;
            }
        }

        return null;
    }
}
