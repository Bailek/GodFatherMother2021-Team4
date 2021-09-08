using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthBar))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyAgent : MonoBehaviour
{
    public Enemy type;

    Rigidbody2D rb;
    HealthBar health;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        health.SetMaxHealth(type.health);
        spriteRenderer.sprite = type.sprite;
    }
    private void Update()
    {
        //rb.velocity = new Vector2(rb.velocity.x + Time.deltaTime * type.speed, rb.velocity.y);
    }
}
