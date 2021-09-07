using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HealthBar))]
public class HealthUI : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    HealthBar health;
    SpriteRenderer spriteRenderer;
    int healthParts;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<HealthBar>();
        if(sprites.Count != 0)
        {
            healthParts = health.maxHealth / sprites.Count;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if(healthParts != 0)
        {
            int spriteNb = health.currentHealth / healthParts;
            Debug.Log(spriteNb);
            spriteRenderer.sprite = sprites[spriteNb];
        }
    }
}
