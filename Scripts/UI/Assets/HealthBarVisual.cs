using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarVisual : MonoBehaviour
{
    private HealthSystem healthSystem;
    private float fullHealthLocalScaleAmount;

    private SpriteRenderer spriteRendererHealthBar;
    private SpriteRenderer spriteRendererBackground;

    private Vector3 currentHealthVisualScale;

    private void Start()
    {
        Setup();
    }

    private void HealthSystem_OnCurrentHealthChanged(object sender, System.EventArgs e)
    {
        UpdateHealthBarVisual();

        ShowHideHealthBar();
    }

    private void ShowHideHealthBar()
    {
        if (healthSystem.CurrentHealthPercentage < 1)
        {
            spriteRendererBackground.enabled = true;
            spriteRendererHealthBar.enabled = true;
        }
        else
        {
            spriteRendererBackground.enabled = false;
            spriteRendererHealthBar.enabled = false;
        }
    }

    private void UpdateHealthBarVisual()
    {
        float currentHealthVisualRatio = fullHealthLocalScaleAmount * healthSystem.CurrentHealthPercentage;

        currentHealthVisualScale = new Vector3(currentHealthVisualRatio, transform.localScale.y, transform.localScale.z);

        transform.localScale = currentHealthVisualScale;
    }

    private void Setup()
    {
        healthSystem = GetComponentInParent<HealthSystem>();

        spriteRendererHealthBar = GetComponent<SpriteRenderer>();
        spriteRendererBackground = transform.parent.GetComponent<SpriteRenderer>();

        fullHealthLocalScaleAmount = transform.localScale.x;

        healthSystem.OnCurrentHealthChanged += HealthSystem_OnCurrentHealthChanged;
    }
}
