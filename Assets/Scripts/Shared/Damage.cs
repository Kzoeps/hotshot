using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damage : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthBar;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount) {
        health -= amount;
        Debug.Log("Damage taken" + health);
        healthBar.SetHealth(health);
        if (health <= 0) {
            Die();
        }
    }

    public abstract void Die();


}