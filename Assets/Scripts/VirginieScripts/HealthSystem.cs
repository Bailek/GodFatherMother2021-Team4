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

    public string deathSound;
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
            SoundManager.Instance.PlaySound(deathSound);
            Destroy(this.gameObject);
            return;
        }
        OnTakeDamage?.Invoke();
    }

    public void HealShip(float value)
    {
        StartCoroutine(healProcess(value));
    }

    IEnumerator healProcess(float value, float seconds = 10f)
    {
        float healPerSec = value / seconds;
        Debug.Log("step " + healPerSec);

        while (value > 0)
        {
            float newHealth = current + healPerSec;
            newHealth = Mathf.Clamp(newHealth, 0, max);
            current = newHealth;
            value -= healPerSec;
            Debug.Log("heal " + current);
            yield return new WaitForSeconds(1f);
        }
        
        yield return null;
    }
}
