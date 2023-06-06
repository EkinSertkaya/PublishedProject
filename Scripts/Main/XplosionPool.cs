using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XplosionPool : MonoBehaviour
{
    public static XplosionPool Instance { get; private set; }

    [SerializeField] private GameObject Xplosion;

    private GameObject[] xPlosionPool = new GameObject[20];

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
        for (int i = 0; i < 20; i++)
        {
            xPlosionPool[i] = Instantiate(Xplosion, transform.position, Quaternion.identity, transform);
            xPlosionPool[i].SetActive(false);
        }
    }

    public GameObject GetFromXplosionPool()
    {
        for (int i = 0; i < xPlosionPool.Length; i++)
        {
            if (!xPlosionPool[i].activeSelf)
            {
                xPlosionPool[i].SetActive(true);
                return xPlosionPool[i];
            }
        }

        return null;
    }
}
