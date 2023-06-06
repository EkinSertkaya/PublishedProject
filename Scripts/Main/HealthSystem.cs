using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnZeroCurrentHealth;
    public event EventHandler OnCurrentHealthChanged;

    [SerializeField] private int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    public float CurrentHealthPercentage { get { return (float)currentHealth / maxHealth; } }

    private int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    private bool isPoisened = false;

    private float poisonTimer = 0f;
    private int poisonDamageAmount;

    private void Start()
    {
        OnZeroCurrentHealth += Death_OnZeroCurrentHealth;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (isPoisened)
        {
            poisonTimer += Time.deltaTime;
            
            if(poisonTimer >= 1f)
            {
                ApplyDamage(poisonDamageAmount);
                poisonTimer -= poisonTimer;
            }
        }
    }

    private void Death_OnZeroCurrentHealth(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

    public void ApplyDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        OnCurrentHealthChanged?.Invoke(this, EventArgs.Empty);

        if (currentHealth <= 0)
        {
            OnZeroCurrentHealth?.Invoke(this, EventArgs.Empty);
        }
    }

    public void ApplyHeal(int healAmount)
    {
        currentHealth += healAmount;
        OnCurrentHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Poison(int poisonDamageAmount)
    {
        isPoisened = true;

        this.poisonDamageAmount = poisonDamageAmount;
    }

    public void CurePoison()
    {
        isPoisened = false;
    }

    private void OnDisable()
    {
        CurePoison();
        currentHealth = maxHealth;
        OnCurrentHealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
