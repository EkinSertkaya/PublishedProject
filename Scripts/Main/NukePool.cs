using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePool : MonoBehaviour
{
    private GameObject[] nukePool = new GameObject[5];
    [SerializeField] private PlayerWeapon playerWeapon;

    [SerializeField] private GameObject nukePf;

    private void Awake()
    {
        for(int i = 0; i < 5; i++)
        {
            nukePool[i] = Instantiate(nukePf, transform.position, Quaternion.identity, transform);
            nukePool[i].GetComponent<Bullet>().PlayerWeapon = this.playerWeapon;
            nukePool[i].SetActive(false);
        }
    }

    public GameObject GetNukeFromPool()
    {
        foreach(GameObject nuke in nukePool)
        {
            if (!nuke.activeSelf)
            {
                return nuke;
            }
        }

        return null;
    }
}
