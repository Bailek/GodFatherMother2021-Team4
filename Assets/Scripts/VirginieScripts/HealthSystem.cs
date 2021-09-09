using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    #region Event
    public delegate void HealthEvent();
    public event HealthEvent OnTakeDamage;
    public event HealthEvent OnHeal;
    #endregion

    public float max = 100.0f;
    [Header("   DEBUG")]
    public float current = 100.0f;

    private void Start()
    {
        current = max;
    }

    public void SetMaxHealth(float value)
    {
        max = value;
        current = max;
    }
    public void TakeDamage(float damage)
    {
        current -= damage;

        if (current <= 0)
        {
            Destroy(this.gameObject);
            return;
        }

        OnTakeDamage?.Invoke();
    }

    public void Heal(float value)
    {
        float newHealth = current + value;
        newHealth = Mathf.Clamp(newHealth, 0, max);
        current = newHealth;

        OnHeal?.Invoke();
    }
}
