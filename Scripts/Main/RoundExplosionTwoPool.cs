using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundExplosionTwoPool : MonoBehaviour
{
    public static RoundExplosionTwoPool Instance { get; private set; }

    [SerializeField] private GameObject roundExplosionTwo;

    private GameObject[] roundExplosionTwoPool = new GameObject[5];

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < 5; i++)
        {
            roundExplosionTwoPool[i] = Instantiate(roundExplosionTwo, transform.position, Quaternion.identity, transform);
            roundExplosionTwoPool[i].SetActive(false);
        }
    }

    public GameObject GetFromRoundExplosionTwoPool()
    {
        for (int i = 0; i < roundExplosionTwoPool.Length; i++)
        {
            if (!roundExplosionTwoPool[i].activeSelf)
            {
                roundExplosionTwoPool[i].SetActive(true);
                return roundExplosionTwoPool[i];
            }
        }

        return null;
    }
}
