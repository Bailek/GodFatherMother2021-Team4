using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HealthSystem))]
public class HealthUI : MonoBehaviour
{
    public List<HealthState> states = new List<HealthState>();
    private HealthSystem health;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<HealthSystem>();
        spriteRenderer.sprite = states[0].sprite;

        health.OnTakeDamage += UpdateState;
        health.OnHeal += UpdateState;
    }

    private void OnDisable()
    {
        health.OnTakeDamage -= UpdateState;
        health.OnHeal -= UpdateState;
    }

    private void UpdateState()
    {
        if (health.current <= 0)
        {
            Debug.Log("Death");
            //GameManager.instance.EndGame();
            return;
        }

        for (int i = states.Count - 1; i >= 0; i--)
        {
            float ceillingPercent = health.max * states[i].minHealthPercentage / 100;
            if (health.current <= ceillingPercent)
            {
                spriteRenderer.sprite = states[i].sprite;
                break;
            }
        }
    }
}

[System.Serializable]
public class HealthState
{
    public float minHealthPercentage;
    public Sprite sprite;
}
