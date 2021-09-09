using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float current = 100.0f;
    public float max = 100.0f;

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
        }
    }
}
