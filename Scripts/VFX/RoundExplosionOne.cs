using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundExplosionOne : MonoBehaviour
{
    private float timer = 0f;

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            timer += Time.deltaTime;

            if(timer >= .5f)
            {
                timer -= timer;
                gameObject.SetActive(false);
            }
        }
    }
}
