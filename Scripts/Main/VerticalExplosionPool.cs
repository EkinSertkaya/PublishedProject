using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalExplosionPool : MonoBehaviour
{
    public static VerticalExplosionPool Instance { get; private set; }

    [SerializeField] private GameObject verticalExpolosion;

    private GameObject[] verticalExplosionPool = new GameObject[5];

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
            verticalExplosionPool[i] = Instantiate(verticalExpolosion, transform.position, Quaternion.identity, transform);
            verticalExplosionPool[i].SetActive(false);
        }
    }

    public GameObject GetFromVerticalExplosionPool()
    {
        for (int i = 0; i < verticalExplosionPool.Length; i++)
        {
            if (!verticalExplosionPool[i].activeSelf)
            {
                verticalExplosionPool[i].SetActive(true);
                return verticalExplosionPool[i];
            }
        }

        return null;
    }
}
