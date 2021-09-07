using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBar))]
[RequireComponent(typeof(Collider2D))]
public class ShipManager : MonoBehaviour
{
    HealthBar health;
    Collider2D collide;

    private void Start()
    {
        collide = GetComponent<Collider2D>();
        health = GetComponent<HealthBar>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        health.TakeDamage(enemy.damage);
    }
}
