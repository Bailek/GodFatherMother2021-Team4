using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthUI))]
public class HealthBar : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;
    public HealthUI healthUI;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
