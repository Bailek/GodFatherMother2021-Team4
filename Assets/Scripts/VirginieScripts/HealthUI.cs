using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HealthSystem))]
public class HealthUI : MonoBehaviour
{
    public List<HealthState> states = new List<HealthState>();
    public Image image;
    private HealthSystem health;
    private SpriteRenderer spriteRenderer;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<HealthSystem>();
       
        spriteRenderer.sprite = states[0].sprite;

        if(image != null)
        {
            image.fillAmount = health.max;
        }
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

        if(image != null)
        {
            image.fillAmount = health.current / health.max;
        }
    }
}

[System.Serializable]
public class HealthState
{
    public float minHealthPercentage;
    public Sprite sprite;
}
