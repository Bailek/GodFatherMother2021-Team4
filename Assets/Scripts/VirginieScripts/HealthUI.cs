using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HealthSystem))]
public class HealthUI : MonoBehaviour
{
    public Sprite fullHealth;
    public Sprite midHealth;
    public Sprite lowHealth;

    HealthSystem health;
    SpriteRenderer spriteRenderer;
    int healthPart;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<HealthSystem>();
        healthPart = (int)(health.maxHealth / 3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if(health.currentHealth <= healthPart)
        {
            spriteRenderer.sprite = lowHealth;
        }else if(health.currentHealth <= healthPart * 2)
        {
            spriteRenderer.sprite = midHealth;
        }
        else
        {
            spriteRenderer.sprite = fullHealth;
        }
    }
}
