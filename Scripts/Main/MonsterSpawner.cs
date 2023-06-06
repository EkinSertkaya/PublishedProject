using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner Instance { get; private set; }

    [SerializeField] private GameObject spawnedMonster1;
    [SerializeField] private GameObject spawnedMonster2;
    [SerializeField] private GameObject spawnedMonster3;
    [SerializeField] private GameObject spawnedMonster4;

    private float smallMonsterSpawnRate = 3f;
    private float mediumMonsterSpawnRate = 10f;
    private float bigMonsterSpawnRate = 30f;
    private float bossMonsterSpawnRate = 40f;

    private float smallMonsterSpawnTimer = 0f;
    private float mediumMonsterSpawnTimer = 0f;
    private float bigMonsterSpawnTimer = 0f;
    private float bossMonsterSpawnTimer = 0f;

    private int smallMonsterCounter = 0;
    private int mediumMonsterCounter = 0;
    private int bigMonsterCounter = 0;
    private int bossMonsterCounter = 0;

    private bool spawning = false;

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

    private void Update()
    {
        if (spawning)
        {
            SpawnMonster();
        }
    }

    private void SpawnMonster()
    {
        smallMonsterSpawnTimer += Time.deltaTime;
        mediumMonsterSpawnTimer += Time.deltaTime;
        bigMonsterSpawnTimer += Time.deltaTime;
        bossMonsterSpawnTimer += Time.deltaTime;


        if(smallMonsterCounter < RulesManager.Instance.SmallMonsterAmount && smallMonsterSpawnTimer >= smallMonsterSpawnRate)
        {
            SpawnRandomMonster(CreatureType.SmallMonster);

            smallMonsterCounter++;
            smallMonsterSpawnTimer -= smallMonsterSpawnTimer;

            smallMonsterSpawnRate = Random.Range(.6f, 1.5f);
        }

        if (mediumMonsterCounter < RulesManager.Instance.MediumMonsterAmount && mediumMonsterSpawnTimer >= mediumMonsterSpawnRate)
        {
            SpawnRandomMonster(CreatureType.MediumMonster);

            mediumMonsterCounter++;
            mediumMonsterSpawnTimer -= mediumMonsterSpawnTimer;

            mediumMonsterSpawnRate = Random.Range(2f, 6f);
        }

        if (bigMonsterCounter < RulesManager.Instance.BigMonsterAmount && bigMonsterSpawnTimer >= bigMonsterSpawnRate)
        {
            SpawnRandomMonster(CreatureType.BigMonster);

            bigMonsterCounter++;
            bigMonsterSpawnTimer -= bigMonsterSpawnTimer;

            bigMonsterSpawnRate = Random.Range(3f, 7f);
        }

        if (bossMonsterCounter < RulesManager.Instance.BossMonsterAmount && bossMonsterSpawnTimer >= bossMonsterSpawnRate)
        {
            SpawnRandomMonster(CreatureType.BossMonster);

            bossMonsterCounter++;
            bossMonsterSpawnTimer -= bossMonsterSpawnTimer;

            bossMonsterSpawnRate = Random.Range(13f, 18f);
        }
    }

    public void SetSpawningTrue()
    {
        spawning = true;
    }

    public void ResetMonsterCounter()
    {
        smallMonsterCounter = 0;
        mediumMonsterCounter = 0;
        bigMonsterCounter = 0;
        bossMonsterCounter = 0;
    }

    private void SpawnRandomMonster(CreatureType creatureType)
    {
        GameObject spawnedMonster = MonsterPool.Instance.GetRandomMonster(creatureType);

        spawnedMonster.transform.position = transform.position;
        spawnedMonster.SetActive(true);
    }

    public void StartSpawning()
    {
        spawning = true;
    }
}
